using System.Collections;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Logic.Database.Models;
using Logic.Enum;
using Logic.ExternalConnection.Wireguard.Repositories;
using Logic.Model.Result.Shared;
using Logic.Logic.Interface;
using Logic.Model.Dto.VpnUser;
using Logic.Repositories;
using Logic.Externsions;
using Logic.Model.Dto.Payment;
using Logic.Model.Dto.User;
using Logic.Model.Result.Shared.Obsolete;

namespace Logic.Logic;

public class VpnUserLogic : BaseLogic, IVpnUserLogic
{
    #region Service constructor and injected dependencies

    private readonly ILogger<VpnUserLogic> _logger;
    private readonly IMapper _mapper;
    private readonly IRepository<VpnUser> _vpnUserRepository;
    [Obsolete("Use UserPaymentRepository")]
    private readonly IRepository<VpnUsersPayments> _vpnUserPaymentsRepository;
    private readonly IRepository<UserPayment> _userPaymentRepository;
    private readonly IRepository<VpnUsersCertificates> _vpnUserCertificatesRepository;
    private readonly IRepository<Server> _serverRepository;
    private readonly IRepository<Certificate> _certificateRepository;
    private readonly IRepository<Region> _regionRepository;
    private readonly IUserLogic _userLogic;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<EmployeeAccess> _employeeAccessRepository;
    private readonly WireGuardRepository _wireGuardRepository;
    private readonly ICertificateLogic _certificateLogic;

    public VpnUserLogic(
        ILogger<VpnUserLogic> logger,
        IMapper mapper,
        IRepository<VpnUser> vpnUserRepository,
        IRepository<VpnUsersPayments> vpnUserPaymentsRepository,
        IRepository<VpnUsersCertificates> vpnUserCertificatesRepository,
        IRepository<Server> serverRepository,
        IRepository<Certificate> certificateRepository,
        IRepository<Region> regionRepository,
        IUserLogic userLogic,
        IRepository<User> userRepository,
        IRepository<EmployeeAccess> employeeAccessRepository,
        WireGuardRepository wireGuardRepository, ICertificateLogic certificateLogic, IRepository<UserPayment> userPaymentRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _vpnUserRepository = vpnUserRepository;
        _vpnUserPaymentsRepository = vpnUserPaymentsRepository;
        _vpnUserCertificatesRepository = vpnUserCertificatesRepository;
        _serverRepository = serverRepository;
        _certificateRepository = certificateRepository;
        _regionRepository = regionRepository;
        _userLogic = userLogic;
        _userRepository = userRepository;
        _employeeAccessRepository = employeeAccessRepository;
        _wireGuardRepository = wireGuardRepository;
        _certificateLogic = certificateLogic;
        _userPaymentRepository = userPaymentRepository;
    }

    #endregion

    public async Task<HandlerResult<Guid>> Add(AddVpnUserRequestModel model)
    {
        if (_vpnUserRepository.Where(u => u.TelegramId == model.TelegramId).Any())
        {
            var message = $"User with telegramId {model.TelegramId} already exists";
            _logger.LogWarning("{}", message);
            return HandlerResult<Guid>.Failure(new Exception(message));
        }

        var vpnUser = _mapper.Map<VpnUser>(model);

        var answer = await _userLogic.Register(new RegisterRequestModel
        {
            Username = model.TelegramId.ToString(),
            Email = model.TelegramId.ToString(),
            Password = "User-Default13"
        },
            UserRoleEnum.Employer);

        var user = await _userRepository.Where(u => u.Email == model.TelegramId.ToString()).FirstOrDefaultAsync();
        if (user == null)
        {
            var message = $"User with email {model.TelegramId} does not exist";
            _logger.LogWarning("{}", message);
            return HandlerResult<Guid>.Failure(new Exception());
        }

        vpnUser.User = user;

        vpnUser = await _vpnUserRepository.AddSaveAsync(vpnUser);

        return HandlerResult<Guid>.Success(vpnUser.Id);
    }

    public class UserQuery
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public string? Filter { get; set; } // by username, first and last names
    }

    public async Task<HandlerResult<Pagination<VpnUserResponseModel>>> List(UserQuery query)
    {
        if (query.Offset < 0)
        {
            const string messageGreaterMessage = "Offset must be greater than 0";
            _logger.LogInformation(messageGreaterMessage);
            return HandlerResult<Pagination<VpnUserResponseModel>>.Failure(messageGreaterMessage);
        }

        switch (query.Limit)
        {
            case < 0:
                const string messageGreaterLimit = "Limit must be greater than 0";
                _logger.LogInformation(messageGreaterLimit);
                return HandlerResult<Pagination<VpnUserResponseModel>>.Failure(messageGreaterLimit);
            case > 100:
                const string messageLessLimit = "Limit must be less than 100";
                _logger.LogInformation(messageLessLimit);
                return HandlerResult<Pagination<VpnUserResponseModel>>.Failure(messageLessLimit);
            default:
                var query_ = _vpnUserRepository.Where(u =>
                query.Filter == null /* always true is null */ || u.Username.Contains(query.Filter)
                        || u.FirstName.Contains(query.Filter)
                        || u.LastName.Contains(query.Filter));
                var list = await query_.Include(u => u.EmployeeAccesses).ThenInclude(a => a.Bundle).ThenInclude(b => b.Employer)
                    .Include(u => u.Region)
                    .Include(u => u.Certificate)
                    .ThenInclude(c => c.Server).Skip(query.Offset).Take(query.Limit).ToListAsync();

                var total = await query_.CountAsync();
                var pagination = new Pagination<VpnUserResponseModel>
                (
                    _mapper.Map<List<VpnUserResponseModel>>(list),
                    query.Limit,
                    query.Offset,
                    total
                );

                return HandlerResult<Pagination<VpnUserResponseModel>>.Success(pagination);
        }
    }

    public async Task<IHandler<VpnUserResponseModel>> Get(Guid id)
    {
        var user = await _vpnUserRepository.Where(u => u.Id == id)
            .Include(u => u.Region)
            .Include(u => u.EmployeeAccesses).ThenInclude(a => a.Bundle).ThenInclude(b => b.Employer)
            .Include(u => u.Certificate)
            .ThenInclude(c => c.Server)
            .Include(u => u.CertificateHistory)
            .FirstOrDefaultAsync();

        return user == null
            ? new HandlerException<VpnUserResponseModel>(_logger, $"User (id: {id}) does not exist")
            : _mapper.Map<VpnUserResponseModel>(user).Wrap();
    }

    public async Task<IHandler<VpnUserResponseModel>> GetByTelegramId(long telegramId)
    {
        var user = await _vpnUserRepository.Where(u => u.TelegramId == telegramId)
            .Include(u => u.Region)
            .Include(u => u.EmployeeAccesses).ThenInclude(a => a.Bundle).ThenInclude(b => b.Employer)
            .Include(u => u.Certificate)
            .ThenInclude(c => c.Server)
            .FirstOrDefaultAsync();

        return user == null
            ? new HandlerException<VpnUserResponseModel>(_logger, $"User (telegramId: {telegramId}) does not exist")
            : _mapper.Map<VpnUserResponseModel>(user).Wrap();
    }

    public async Task ChangeUserBalance(Guid id, int value)
    {
        var user = await _vpnUserRepository.Where(u => u.Id == id).FirstAsync();
        user.Balance = value;
        await _vpnUserRepository.UpdateSaveAsync(user);
    }

    public async Task AddUserBalance(Guid id, int value)
    {
        var user = await _vpnUserRepository.Where(u => u.Id == id).FirstAsync();
        user.Balance = user.Balance + value;
        await _vpnUserRepository.UpdateSaveAsync(user);
    }

    public async Task<IHandler<bool>> ChangeRegion(Guid userId, Guid regionId)
    {
        var user = await _vpnUserRepository.Where(u => u.Id == userId).Include(u => u.Certificate)
            .ThenInclude(c => c.Server).FirstOrDefaultAsync();
        if (user == null)
            return new HandlerException<bool>(_logger, $"User (id: {userId}) does not exist");

        var region = await _regionRepository.Where(r => r.Id == regionId).FirstOrDefaultAsync();
        if (region == null)
            return new HandlerException<bool>(_logger, $"Region (id: {regionId}) does not exist");

        user.RegionId = region.Id;
        await _vpnUserRepository.UpdateSaveAsync(user);

        if (user.CertificateId == null)
            return new Handler<bool>(true);

        var oldCertificate = user.Certificate;

        var exemptResult = await ExemptCertificate(user);
        if (exemptResult is HandlerException<bool>)
            return exemptResult;

        await _vpnUserRepository.UpdateSaveAsync(user);
        // if (oldCertificate != null) await _certificateRepository.DeleteSaveAsync(oldCertificate);
        // TODO old certificate to history

        return new Handler<bool>(true);
    }

    public async Task<IHandler<byte[]>> QrCodeConfig(Guid id)
    {
        var user = await _vpnUserRepository.Where(u => u.Id == id)
            .Include(u => u.Certificate).ThenInclude(c => c.Server)
            .FirstOrDefaultAsync();

        return user switch
        {
            null => new HandlerException<byte[]>(_logger, $"User with id {id} does not exist in database"),
            not null when user.Certificate is null => new HandlerException<byte[]>(
                _logger, $"This user ({id}) does not have an active certificate"),
            not null => (await _wireGuardRepository.QrCodeConfig(user.Certificate.Server.Host,
                user.Certificate.PublicKey)).Wrap()
        };
    }

    public async Task<IHandler<string>> TextConfig(Guid id)
    {
        var user = await _vpnUserRepository.Where(u => u.Id == id)
            .Include(u => u.Certificate).ThenInclude(c => c.Server)
            .FirstOrDefaultAsync();

        return user switch
        {
            null => new HandlerException<string>(_logger, $"User with id {id} does not exist in database"),
            not null when user.Certificate is null => new HandlerException<string>(_logger,
                $"This user ({id}) does not have an active certificate"),
            not null => (await _wireGuardRepository.TextConfig(user.Certificate.Server.Host,
                    user.Certificate.PublicKey))
                .Wrap()
        };
    }

    public async Task<IHandler<bool>> UserUpdateCertificate(Guid id)
    {
        var user = await _vpnUserRepository.Where(u => u.Id == id)
            .Include(u => u.EmployeeAccesses).ThenInclude(a => a.Bundle).ThenInclude(b => b.Employer)
            .Include(u => u.Region)
            .Include(u => u.Certificate).ThenInclude(c => c.Server)
            .FirstOrDefaultAsync();

        switch (user)
        {
            case null:
                return new HandlerException<bool>(_logger, $"User with id {id} does not exist in database");
            case { Balance: < 1, EmployeeAccesses.Count: 0 } when user.EmployeeAccesses.Single().Bundle.Balance < 1:
                return new HandlerException<bool>(_logger, $"User with id {id} mast pay money, or get employee access");
        }

        if (user.Region is null)
            return new HandlerException<bool>(_logger, $"User ({id}) does not have server region");

        if (user.Certificate is not null)
        {
            var exemptResult = await ExemptCertificate(user);
            if (exemptResult is HandlerException<bool>)
                return exemptResult;
        }

        var server = await _serverRepository.Where(s => true).OrderBy(s => s.CountUsers)
            .FirstOrDefaultAsync(s => s.Region.Id == user.Region.Id);

        if (server is null)
            return new HandlerException<bool>(_logger,
                $"The server in {user.Region.Name} region does not exist in database");

        var publicKey = await _wireGuardRepository.NewPeer(server.Host);

        var certificate = new Certificate
        {
            ServerId = server.Id,
            PublicKey = publicKey,
        };

        await _certificateRepository.AddSaveAsync(certificate);
        user.CertificateId = certificate.Id;
        await _vpnUserRepository.UpdateSaveAsync(user);
        server.CountUsers++;
        await _serverRepository.UpdateSaveAsync(server);

        return new Handler<bool>(true);
    }

    // TODO to some repo
    public async Task<IHandler<bool>> ExemptCertificate(VpnUser user)
    {
        if (user.Certificate == null)
        {
            return new HandlerException<bool>(_logger, $"User ({user.Id}) does not have certificate");
        }

        if (user.Certificate.Server == null)
        {
            return new HandlerException<bool>(_logger, $"User ({user.Id}) does not have server");
        }


        var certificate = user.Certificate;

        try
        {
            await _certificateLogic.UpdateBytesForPeer(certificate);
            await _certificateRepository.UpdateSaveAsync(certificate);
        }
        catch
        {
            _logger.LogCritical("your new code is shit");
        }

        await PullUserCertificateToHistory(user, certificate);

        try
        {
            // await WireGuardRepository.

            await _wireGuardRepository.DeletePeer(certificate!.Server.Host, certificate.PublicKey);
            certificate.Server.CountUsers--;
            await _serverRepository.UpdateSaveAsync(certificate!.Server);
        }
        catch (Exception exception)
        {
            _logger.LogCritical(
                $"DELETE PEER REQUEST ERROR \nONE OF USER ({user.Id}) MAYBE HAVE MORE THAT ONE ACTIVE PEERS (MAY MANUALLY FIX) \n{exception.GetAllMessagesIntoString()}");
        }

        return new Handler<bool>(true);
    }

    private async Task<IHandler<bool>> PullUserCertificateToHistory(VpnUser user, Certificate certificate)
    {
        var vpnUserCertificate = new VpnUsersCertificates()
        {
            VpnUserId = user.Id,
            CertificateId = certificate.Id
        };

        await _vpnUserCertificatesRepository.AddSaveAsync(vpnUserCertificate);

        user.Certificate = null;
        user.CertificateId = null;

        await _vpnUserRepository.UpdateSaveAsync(user);

        return true.Wrap();
    }

    public async Task<IHandler<bool>> UseFreePeriod(Guid id)
    {
        var user = await _vpnUserRepository.Where(u => u.Id == id).FirstOrDefaultAsync();

        if (user is null)
            return new HandlerException<bool>(_logger, $"User with id {id} does not exist in database");

        user.Balance = 3;
        user.FreePeriodUsed = true;
        await _vpnUserRepository.UpdateSaveAsync(user);

        return new Handler<bool>(true);
    }

    public async Task<IHandler<bool>> DecreaseBalancesAndUpdateTime()
    {
        var vpnUsers = await _vpnUserRepository
            .Where(u => u.Balance > 0 &&
                        (u.EmployeeAccesses.Count == 0 || u.EmployeeAccesses.Any(a => a.Bundle.Balance < 1)))
            .Include(u => u.Certificate).ThenInclude(c => c.Server).ToListAsync();


        var now = DateTime.Now.ToUniversalTime();
        foreach (var user in vpnUsers.Where(user => user.DateOfLastBalanceDecrease < now.AddDays(-1)))
        {
            user.Balance--;
            user.DateOfLastBalanceDecrease = now;

            if (user is not { Balance: 0, Certificate: not null }) continue;
            var exemptResult = await ExemptCertificate(user);
            if (exemptResult is HandlerException<bool>)
                return exemptResult;
        }

        await _vpnUserRepository.UpdateRangeSaveAsync(vpnUsers);
        return new Handler<bool>(true);
    }

    public async Task<HandlerResult> Delete(Guid id)
    {
        // TODO vpn user now depended to user
        var user = await _vpnUserRepository.Where(u => u.Id == id)
#pragma warning disable CS0618
            .Include(vu => vu.PaymentHistory) // for resolve problem with old data
#pragma warning restore CS0618
            .Include(vu => vu.Certificate)
            .Include(vu => vu.CertificateHistory)
            .Include(vu => vu.User)
            .Include(vu => vu.EmployeeAccesses)
            .FirstOrDefaultAsync();

        if (user is null)
            return HandlerResult.Failure(new Exception("Vpn user not found"));

        if (user?.User is not null)
            await _userLogic.Delete(user.User.Id);

        var accesses = user?.EmployeeAccesses.ToList();
        if (accesses != null)
        {
            foreach (var access in accesses)
            {
                access.VpnUserId = null;
            }

            await _employeeAccessRepository.UpdateRangeSaveAsync(accesses);
        }

        if (user!.CertificateHistory is null)
            return HandlerResult.Failure(new Exception("Certificate history not found"));
        await _vpnUserCertificatesRepository.DeleteRangeSaveAsync(user.CertificateHistory);

#pragma warning disable CS0618 
        { // for resolve problem with old data
            if (user.PaymentHistory is null)
                return HandlerResult.Failure(new Exception("Payment history not found"));
            await _vpnUserPaymentsRepository.DeleteRangeSaveAsync(user.PaymentHistory);
        }
#pragma warning restore CS0618

        user.Certificate = null;
        await _vpnUserRepository.UpdateSaveAsync(user);
        await _vpnUserRepository.DeleteSaveAsync(user);
        return HandlerResult.Success("Success");
    }

    public async Task<IList<PaymentUserHistoryItemModel>> GetPaymentHistory(Guid id)
    {
        var vpnUser = await _vpnUserRepository.Where(u => u.Id == id).SingleOrDefaultAsync();
        if (vpnUser is null)
            return new ListException<PaymentUserHistoryItemModel>(_logger,
                $"User with id {id} does not exist in database");
        var user = await _userRepository.Where(u => u.Id == vpnUser.UserId).SingleOrDefaultAsync();
        if (user is null)
            return new ListException<PaymentUserHistoryItemModel>(_logger,
        $"User with id {id} does not exist in database");
        var paymentHistory = await _userPaymentRepository.Where(up => up.UserId == user.Id && up.Payment.Paid).Select(item => item.Payment).ToListAsync();

        return _mapper.Map<List<PaymentUserHistoryItemModel>>(paymentHistory);
    }

    public async Task<IList<VpnUserResponseModel>> SimpleSearch(string searchTerm)
    {
        searchTerm = searchTerm.ToLower();
        var users = await _vpnUserRepository.Where(u =>
                u.FirstName != null && u.FirstName.ToLower().Contains(searchTerm)
                || u.LastName != null && u.LastName.ToLower().Contains(searchTerm)
                || u.Username != null && u.Username.ToLower().Contains(searchTerm))
            .Include(u => u.Region)
            .Include(u => u.EmployeeAccesses).ThenInclude(a => a.Bundle).ThenInclude(b => b.Employer)
            .Include(u => u.Certificate)
            .ThenInclude(c => c.Server)
            .ToListAsync();

        return _mapper.Map<List<VpnUserResponseModel>>(users);
    }

    public async Task<IHandler<bool>> ConnectToEmployer(Guid id, Guid code)
    {
        var access = await _employeeAccessRepository.Where(ea => ea.VpnUserId == id).SingleOrDefaultAsync();
        if (access != null)
            return new HandlerException<bool>(_logger, "User Already Employed");

        access = await _employeeAccessRepository.Where(ea => ea.Code == code).SingleOrDefaultAsync();
        if (access == null)
            return new HandlerException<bool>(_logger, "Code is not valid");

        access.VpnUserId = id;
        await _employeeAccessRepository.UpdateSaveAsync(access);

        return new Handler<bool>(true);
    }

    public async Task<IHandler<bool>> IsEmployed(Guid id)
    {
        var access = await _employeeAccessRepository.Where(ea => ea.VpnUserId == id).SingleOrDefaultAsync();
        return access == null ? new Handler<bool>(false) : new Handler<bool>(true);
    }

    public async Task<IHandler<bool>> IsExist(long telegramId)
    {
        var user = await _vpnUserRepository.Where(u => u.TelegramId == telegramId).SingleOrDefaultAsync();
        return user == null ? new Handler<bool>(false) : new Handler<bool>(true);
    }

}