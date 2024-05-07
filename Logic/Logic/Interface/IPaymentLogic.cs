using Logic.ExternalConnection.Iokassa.Model;
using logic.Model.Dto;
using Logic.Model.Dto.Payment;
using Logic.Model.Dto.VpnUser;
using Logic.Model.Result.Shared;
using Logic.Model.Result.Shared.Obsolete;

namespace Logic.Logic.Interface;

public interface IPaymentLogic: IBaseLogic
{

    public Task<IHandler<string>> CreatePayKeeperPayment(CreatePaykeeperPaymentRequestModel model);
    public Task<IHandler<string>> CreateYookassaPayment(CreateYookassaPaymentRequestModel model);
    [Obsolete("Use CreateYookassaPayment instead")]
    public Task<IHandler<string>> CreateIokassaPayment(CreatePaymentRequestModel model);

    public Task<IHandler<bool>> HandleIokassaPayment(PaymentNotification model);

    public Task<IHandler<bool>> PaykeeperStatusCheck();

    public Task<HandlerResult<Pagination<PaymentHistoryItemModel>>> History(PaymentLogic.HistoryQuery query);
}