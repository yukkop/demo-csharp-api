using Logic.Database.Models;
using Logic.Model.Result.Shared;
using Logic.Model.Dto.VpnUser;
using Logic.Model.Dto.Payment;
using Logic.Model.Result.Shared.Obsolete;
using static Logic.Logic.VpnUserLogic;

namespace Logic.Logic.Interface;

public interface IVpnUserLogic : IBaseLogic
{
    public Task<HandlerResult<Guid>> Add(AddVpnUserRequestModel model);

    public Task<HandlerResult<Pagination<VpnUserResponseModel>>> List(UserQuery query);

    public Task<IHandler<VpnUserResponseModel>> Get(Guid id);

    public Task<IHandler<VpnUserResponseModel>> GetByTelegramId(long telegramId);

    public Task ChangeUserBalance(Guid id, int value);

    public Task AddUserBalance(Guid id, int value);

    public Task<HandlerResult> Delete(Guid id);

    public Task<IHandler<bool>> ChangeRegion(Guid userId, Guid regionId);

    public Task<IHandler<byte[]>> QrCodeConfig(Guid id);

    public Task<IHandler<string>> TextConfig(Guid id);

    public Task<IHandler<bool>> UserUpdateCertificate(Guid id);

    public Task<IHandler<bool>> UseFreePeriod(Guid id);

    public Task<IHandler<bool>> DecreaseBalancesAndUpdateTime();

    public Task<IList<PaymentUserHistoryItemModel>> GetPaymentHistory(Guid id);

    public Task<IList<VpnUserResponseModel>> SimpleSearch(string searchTerm) ;

    public Task<IHandler<bool>> ConnectToEmployer(Guid id, Guid code);

    public Task<IHandler<bool>> IsEmployed(Guid id);

    public Task<IHandler<bool>> IsExist(long telegramId);

    // TODO to some repo
    public Task<IHandler<bool>> ExemptCertificate(VpnUser user);
}