using System.Collections;
using Logic.Externsions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Logic.Database.Models;
using Logic.Enum;
using Logic.Extensions;
using Logic.ExternalConnection.Iokassa.Model;
using Logic.ExternalConnection.Iokassa.Repositories;
using Logic.ExternalConnection.Paykeeper.Repositories;
using Logic.ExternalConnection.TelegramSubscribers.Repositories;
using Logic.Logic.Interface;
using Logic.Model.Result.Shared;
using Logic.Repositories;
using logic.Model.Dto;
using Logic.Model.Dto.Payment;
using Logic.Model.Dto.User;
using Logic.Model.Dto.VpnUser;
using Logic.Model.Result.Shared.Obsolete;
using Microsoft.AspNetCore.Mvc;

namespace Logic.Logic;

public class PaymentLogic : BaseLogic, IPaymentLogic
{
    #region Service constructor and injected dependencies

    private readonly TelegramAgentRepository _telegramAgentRepository;
    private readonly IConfiguration _configuration;
    private readonly ILogger<PaymentLogic> _logger;
    private readonly IRepository<Payment> _paymentRepository;
    private readonly IRepository<VpnUser> _vpnUserRepository;
    private readonly IMapper _mapper;

    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Tariff> _tariffRepository;

    private readonly IUserLogic _userLogic;

    // Deprecated
    private readonly IRepository<VpnUsersPayments> _vpnUserPaymentRepository;
    private readonly IRepository<UserPayment> _userPaymentRepository;
    private readonly IokassaRepository _iokassaRepository;
    private readonly PaykeeperRepository _paykeeperRepository;

    public PaymentLogic(
        TelegramAgentRepository telegramAgentRepository,
        IConfiguration configuration,
        ILogger<PaymentLogic> logger,
        IRepository<Payment> paymentRepository,
        IRepository<VpnUser> vpnUserRepository,
        IRepository<VpnUsersPayments> vpnUserPaymentRepository,
        IokassaRepository iokassaRepository,
        IRepository<UserPayment> userPaymentRepository,
        IRepository<Tariff> tariffRepository,
        IRepository<User> userRepository,
        IUserLogic userLogic,
        PaykeeperRepository paykeeperRepository, IMapper mapper)
    {
        _telegramAgentRepository = telegramAgentRepository;
        _configuration = configuration;
        _logger = logger;
        _paymentRepository = paymentRepository;
        _vpnUserRepository = vpnUserRepository;
        _vpnUserPaymentRepository = vpnUserPaymentRepository;
        _iokassaRepository = iokassaRepository;
        _userPaymentRepository = userPaymentRepository;
        _tariffRepository = tariffRepository;
        _userRepository = userRepository;
        _userLogic = userLogic;
        _paykeeperRepository = paykeeperRepository;
        _mapper = mapper;
    }

    #endregion

    public async Task<IHandler<string>> CreatePayKeeperPayment(CreatePaykeeperPaymentRequestModel model)
    {
        var vpnUser = await _vpnUserRepository.Where(u => u.Id == model.VpnUserId).FirstOrDefaultAsync();
        if (vpnUser is null)
            return new HandlerException<string>(_logger, $"VpnUser with id {model.VpnUserId} do not exist");

        User? user; // legacy defend from null
        if (vpnUser.UserId is null)
        {
            _logger.LogWarning($"VpnUser with id {model.VpnUserId} do not have UserId");

            var answer = await _userLogic.Register(new RegisterRequestModel
                {
                    Username = vpnUser.TelegramId.ToString(),
                    Email = vpnUser.TelegramId.ToString(),
                    Password = "User-Default13"
                },
                UserRoleEnum.Employer);

            user = await _userRepository.Where(u => u.Email == vpnUser.TelegramId.ToString()).FirstOrDefaultAsync();
            if (user == null)
                return new HandlerException<string>(_logger, "KAK BLEAT'????", LogType.Critical);

            vpnUser.User = user;
        }
        else
        {
            user = await _userRepository.Where(u => u.Id == vpnUser.UserId).FirstOrDefaultAsync();
        }

        var tariff = await _tariffRepository.Where(t => t.Id == model.TariffId).FirstOrDefaultAsync();

        if (tariff is null)
            return new HandlerException<string>(_logger, $"Tariff with id {model.TariffId} do not exist");
        if (user is null)
            return new HandlerException<string>(_logger, $"User with id {model.VpnUserId} do not exist",
                LogType.Critical);

        var orderId = Guid.NewGuid();
        var (link, invoiceId) =
            (await _paykeeperRepository.CreatePayment(tariff.Price, user.UserName, orderId)).Unwrap();

        // non lo so
        var payment = new Payment
        {
            IdempotenceKey = orderId,
            ReturnUrl = "-",
            ConfirmationUrl = link,
            Value = (int)tariff.Price,
            Currency = "RUB",
            Paid = false,
            PaymentId = invoiceId,
            RefundedValue = 0,
            IncomeValue = 0,
            CapturedAt = null,
            Refundable = false,
            CreatedAt = DateTime.Now,
            Integration = "PayKeeper",
        };

        await _paymentRepository.AddSaveAsync(payment);

        var userPayment = new UserPayment
        {
            UserId = user.Id,
            PaymentId = payment.Id,
            TariffId = model.TariffId
        };

        await _userPaymentRepository.AddSaveAsync(userPayment);

        return new Handler<string>(payment.ConfirmationUrl);
    }

    public async Task<IHandler<string>> CreateYookassaPayment(CreateYookassaPaymentRequestModel model)
    {
        var vpnUser = await _vpnUserRepository.Where(u => u.Id == model.VpnUserId).FirstOrDefaultAsync();
        if (vpnUser is null)
            return new HandlerException<string>(_logger, $"VpnUser with id {model.VpnUserId} do not exist");

        User? user; // legacy defend from null
        if (vpnUser.UserId is null)
        {
            _logger.LogWarning($"VpnUser with id {model.VpnUserId} do not have UserId");

            var answer = await _userLogic.Register(new RegisterRequestModel
                {
                    Username = vpnUser.TelegramId.ToString(),
                    Email = vpnUser.TelegramId.ToString(),
                    Password = "User-Default13"
                },
                UserRoleEnum.Employer);

            user = await _userRepository.Where(u => u.Email == vpnUser.TelegramId.ToString()).FirstOrDefaultAsync();
            if (user == null)
                return new HandlerException<string>(_logger, "KAK BLEAT'????", LogType.Critical);

            vpnUser.User = user;
        }
        else
        {
            user = await _userRepository.Where(u => u.Id == vpnUser.UserId).FirstOrDefaultAsync();
        }

        var tariff = await _tariffRepository.Where(t => t.Id == model.TariffId).FirstOrDefaultAsync();

        if (tariff is null)
            return new HandlerException<string>(_logger, $"Tariff with id {model.TariffId} do not exist");
        if (user is null)
            return new HandlerException<string>(_logger, $"User with id {model.VpnUserId} do not exist",
                LogType.Critical);

        var idempotentKey = Guid.NewGuid();
        var (ioKassaRequest, ioKassaResponse) =
            (await _iokassaRepository.CreatePayment(tariff.Price, model.ReturnUrl, idempotentKey)).Unwrap();

        var payment = new Payment
        {
            IdempotenceKey = idempotentKey,
            ReturnUrl = ioKassaRequest.Confirmation.ReturnUrl,
            ConfirmationUrl = ioKassaResponse.Confirmation.ConfirmationUrl,
            Value = (int)tariff.Price,
            Currency = ioKassaRequest.Amount.Currency,
            Paid = ioKassaResponse.Test,
            PaymentId = ioKassaResponse.Id,
            RefundedValue = 0,
            IncomeValue = 0,
            CapturedAt = null,
            Refundable = ioKassaResponse.Refundable,
            CreatedAt = ioKassaResponse.CreatedAt,
            Integration = "Yookassa"
        };

        await _paymentRepository.AddSaveAsync(payment);

        var userPayment = new UserPayment
        {
            UserId = user.Id,
            PaymentId = payment.Id,
            TariffId = model.TariffId
        };

        await _userPaymentRepository.AddSaveAsync(userPayment);

        return new Handler<string>(payment.ConfirmationUrl);
    }

    #region Deprecated

    [Obsolete("Use CreateYookassaPayment instead")]
    public async Task<IHandler<string>> CreateIokassaPayment(CreatePaymentRequestModel model)
    {
        var vpnUser = await _vpnUserRepository.Where(u => u.Id == model.VpnUserId).FirstOrDefaultAsync();
        if (vpnUser is null)
            return new HandlerException<string>(_logger, $"User with id {model.VpnUserId} do not exist");

        var idempotentKey = Guid.NewGuid();
        var (ioKassaRequest, ioKassaResponse) =
            (await _iokassaRepository.CreatePayment(model.Value, model.ReturnUrl, idempotentKey)).Unwrap();

        var payment = new Payment
        {
            IdempotenceKey = idempotentKey,
            ReturnUrl = ioKassaRequest.Confirmation.ReturnUrl,
            ConfirmationUrl = ioKassaResponse.Confirmation.ConfirmationUrl,
            Value = model.Value,
            Currency = ioKassaRequest.Amount.Currency,
            Paid = ioKassaResponse.Test,
            PaymentId = ioKassaResponse.Id,
            RefundedValue = 0,
            IncomeValue = 0,
            CapturedAt = null,
            Refundable = ioKassaResponse.Refundable,
            CreatedAt = ioKassaResponse.CreatedAt,
            Integration = "Yookassa"
        };

        await _paymentRepository.AddSaveAsync(payment);

        var vpnUserPayment = new VpnUsersPayments
        {
            VpnUserId = vpnUser.Id,
            PaymentId = payment.Id,
            ValueToBalance = model.ValueToBalance
        };

        await _vpnUserPaymentRepository.AddSaveAsync(vpnUserPayment);

        return new Handler<string>(payment.ConfirmationUrl);
    }

    #endregion

    public async Task<IHandler<bool>> HandleIokassaPayment(PaymentNotification model)
    {
        if (model.Type != "notification") return new HandlerException<bool>(_logger, "Is not notification");

        var payment = await _paymentRepository.Where(p => p.PaymentId == model.Object.Id)
            .FirstOrDefaultAsync();
        if (payment == null)
            return new HandlerException<bool>(_logger, $"Payment with id {model.Object.Id} did not send");

        payment.IncomeValue = float.Parse(model.Object.IncomeAmount.Value);
        payment.RefundedValue = float.Parse(model.Object.RefundedAmount.Value);
        payment.Paid = model.Object.Paid;
        payment.CapturedAt = model.Object.CapturedAt;

        var relation = await _userPaymentRepository
            .Where(r => r.PaymentId == payment.Id)
            .Include(r => r.Tariff)
            .ThenInclude(t => t.PeriodUnit)
            .FirstOrDefaultAsync();

        if (relation is null)
            return new HandlerException<bool>(_logger,
                $"Relation payment (id: {payment.Id}) to any vpn user does not exist");


        await _paymentRepository.UpdateSaveAsync(payment);

        try
        {
            var vpnUser = await _vpnUserRepository.Where(u => u.UserId == relation.UserId).FirstAsync();
            var valueToBalance = CalculatePeriod(relation.Tariff.Period, relation.Tariff.PeriodUnit);
            vpnUser.Balance += valueToBalance;
            _logger.LogInformation("Payment notify user {0} with value {1}", vpnUser.TelegramId,
                valueToBalance);
            await _vpnUserRepository.UpdateSaveAsync(vpnUser);
            await _telegramAgentRepository.PaymentNotify(vpnUser.TelegramId, valueToBalance);
        }
        catch (Exception exception)
        {
            return new HandlerException<bool>(_logger,
                $"BALANCE UPDATE ERROR \nUSER DIDN'T GET HIS MONEY \n{exception.GetAllMessagesIntoString()}",
                LogType.Critical);
        }


        return new Handler<bool>(true);
    }

    private static int CalculatePeriod(int period, PeriodUnit unit)
    {
        var now = DateTime.Today;
        DateTime futureDate;

        if (unit.Unit.Equals("day", StringComparison.OrdinalIgnoreCase))
        {
            futureDate = now.AddDays(period);
        }
        else if (unit.Unit.Equals("month", StringComparison.OrdinalIgnoreCase))
        {
            futureDate = now.AddMonths(period);
        }
        else if (unit.Unit.Equals("year", StringComparison.OrdinalIgnoreCase))
        {
            futureDate = now.AddYears(period);
        }
        else
        {
            throw new ArgumentException("Invalid unit");
        }

        var difference = futureDate - now;
        return (int)difference.TotalDays;
    }

    public async Task<IHandler<bool>> HandlePaykeeperPayment(PaymentNotification model)
    {
        _configuration.GetValue<string>("Paykeeper:Secret");

        return new Handler<bool>(true);
    }

    public async Task<IHandler<bool>> PaykeeperStatusCheck()
    {
        // curl -X GET -H "Content-Type: application/x-www-form-urlencoded" -H "Authorization: Basic $(echo -n 'yukkop:#h6f%m9L7@!G' | base64)" "https://helpexcel.server.paykeeper.ru/info/invoice/byid/?id=20230612012202653" | jq

        var payments = await _paymentRepository.Where(p => p.Paid == false && p.Integration == "PayKeeper")
            .ToListAsync();

        foreach (var payment in payments)
        {
            var response = await _paykeeperRepository.InvoiceInfo(payment.PaymentId);
            var invoiceInfo = response.Unwrap();
            DateTime? date;
            if (invoiceInfo.Status != "paid")
            {
                // _logger.LogInformation("Invoice {0} not paid yet", payment.Id);
                var paymentsInfo = (await _paykeeperRepository.PaymentInfo(payment.IdempotenceKey)).Unwrap();

                paymentsInfo = paymentsInfo.Where(paymentInfo => paymentInfo.Status is "success" or "obtained")
                    .ToList();
                switch (paymentsInfo.Count)
                {
                    case 0:
                        // _logger.LogInformation("Payment {0} not founded yet", payment.Id);
                        continue;
                    case > 1:
                        _logger.LogCritical("PaykeeperStatusCheck: Invoice have more than one obtained payment");
                        break;
                }

                date = paymentsInfo.First().ObtainDateTime;
            }
            else
            {
                if (invoiceInfo.PaidDatetime == null)
                {
                    _logger.LogCritical("PaykeeperStatusCheck: Invoice {0} paid but paidDatetime is null",
                        invoiceInfo.Id);
                }

                date = invoiceInfo.PaidDatetime;
            }

            payment.Paid = true;
            payment.CapturedAt = date;

            // get vpnUser через UserPayment and User
            var userPayment = await _userPaymentRepository.Where(up => up.PaymentId == payment.Id)
                .Include(u => u.Tariff).ThenInclude(t => t.PeriodUnit)
                .FirstOrDefaultAsync();
            if (userPayment is null)
            {
                _logger.LogCritical("PaykeeperStatusCheck: UserPayment with paymentId {0} not found", payment.Id);
                continue;
            }

            try
            {
                var vpnUser = await _vpnUserRepository.Where(vu => vu.UserId == userPayment.UserId).FirstAsync();
                var valueToBalance = CalculatePeriod(userPayment.Tariff.Period, userPayment.Tariff.PeriodUnit);
                vpnUser.Balance += valueToBalance;
                _logger.LogInformation("PaykeeperStatusCheck: Payment notify user {0} with value {1}",
                    vpnUser.TelegramId,
                    valueToBalance);
                await _vpnUserRepository.UpdateSaveAsync(vpnUser);
                await _telegramAgentRepository.PaymentNotify(vpnUser.TelegramId, valueToBalance);
            }
            catch (Exception exception)
            {
                return new HandlerException<bool>(_logger,
                    $"PaykeeperStatusCheck: BALANCE UPDATE ERROR \nUSER DIDN'T GET HIS MONEY \n{exception.GetAllMessagesIntoString()}",
                    LogType.Critical);
            }

            await _paymentRepository.UpdateSaveAsync(payment);
        }

        return new Handler<bool>(true);
    }

    public class HistoryQuery
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string? Filter { get; set; } = "";
        public List<Guid>? VpnUserIds { get; set; } = new();
    }

    private static bool GetValue(Payment item, string attributeName)
    {
        return attributeName switch
        {
            "test" => item.Test,
            "paid" => item.Paid,
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<HandlerResult<Pagination<PaymentHistoryItemModel>>> History(HistoryQuery query)
    {
        if (query.Offset < 0)
        {
            const string messageGreaterMessage = "Offset must be greater than 0";
            _logger.LogInformation(messageGreaterMessage);
            return HandlerResult<Pagination<PaymentHistoryItemModel>>.Failure(messageGreaterMessage);
        }
        
        switch (query.Limit)
        {
            case < 0:
                const string messageGreaterLimit = "Limit must be greater than 0";
                _logger.LogInformation(messageGreaterLimit);
                return HandlerResult<Pagination<PaymentHistoryItemModel>>.Failure(messageGreaterLimit);
            case > 100:
                const string messageLessLimit = "Limit must be less than 100";
                _logger.LogInformation(messageLessLimit);
                return HandlerResult<Pagination<PaymentHistoryItemModel>>.Failure(messageLessLimit);
            default:
            {
                var historyQuery = _paymentRepository.Where(p => true);

                try
                {
                    var expression = query.Filter;
                    if (!string.IsNullOrEmpty(expression))
                    {
                        var tokens = expression.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        string? currentOperator = null;

                        foreach (var token in tokens)
                        {
                            switch (token)
                            {
                                /*
                                case "|" when currentOperator != null:
                                    throw new ArgumentException("Invalid expression");
                                case "|":
                                    currentOperator = "OR";
                                    break;
                                */
                                case "&" when currentOperator != null:
                                    throw new ArgumentException("Invalid expression");
                                case "&":
                                    currentOperator = "AND";
                                    break;
                                case "!":
                                    if (currentOperator != null)
                                        currentOperator += " NOT";
                                    else
                                        currentOperator += "NOT"; // for first token
                                    break;
                                default:
                                    if (token is not ("test" or "paid"))
                                        throw new ArgumentException("Invalid expression");
                                    
                                    historyQuery = currentOperator switch
                                    {
                                        /*
                                        "OR" => historyQuery.Where(item => token == "test" ? item.Test : item.Paid),
                                        "OR NOT" => historyQuery.Where(item => !(token == "test" ? item.Test : item.Paid)),
                                        */
                                        "AND" => historyQuery.Where(item => token == "test" ? item.Test : item.Paid),
                                        "AND NOT" => historyQuery.Where(item => !(token == "test" ? item.Test : item.Paid)),
                                        "NOT" => historyQuery.Where(item => !(token == "test" ? item.Test : item.Paid)), // for first token
                                        _ => historyQuery.Where(item => token == "test" ? item.Test : item.Paid) // for first token
                                    };
                                    
                                    currentOperator = null;
                                    break;
                            }
                        }

                        if (currentOperator != null)
                            throw new ArgumentException("Invalid expression");
                    }
                }
                catch (ArgumentException e)
                {
                    _logger.LogCritical("{}", e.Message);
                    return HandlerResult<Pagination<PaymentHistoryItemModel>>.Failure(e.Message);
                }

                if (query.From != null)
                    historyQuery = historyQuery.Where(p => p.CreatedAt >= query.From);
                if (query.To != null)
                    historyQuery = historyQuery.Where(p => p.CreatedAt <= query.To);

                if (query.VpnUserIds?.Count > 0)
                {
                    var userIds = await _userRepository.Where(u => query.VpnUserIds.Contains(u.VpnUser.Id))
                        .Select(u => u.Id).ToListAsync();
                    historyQuery =
                        historyQuery.Where(p => p.UserPayments.Any(up => userIds.Contains(up.UserId)));
                }
                
                var totalCount = await historyQuery.CountAsync();

                var historyItems = await historyQuery
                    .Skip(query.Offset).Take(query.Limit).Include(p => p.UserPayments).ThenInclude(up => up.User)
                    .ThenInclude(u => u.VpnUsers).ToListAsync();
                
                var pagination = new Pagination<PaymentHistoryItemModel>(_mapper.Map<List<PaymentHistoryItemModel>>(historyItems), query.Limit, query.Offset, totalCount);
                return HandlerResult<Pagination<PaymentHistoryItemModel>>.Success(pagination);
            }
        }
    }
}