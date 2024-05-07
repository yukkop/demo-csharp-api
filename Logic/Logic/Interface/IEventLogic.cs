using Logic.Model.Dto;
using Logic.Model.Result.Shared;
using Logic.Model.Result.Shared.Obsolete;

namespace Logic.Logic.Interface;

public interface IEventLogic: IBaseLogic
{
    public Task<IHandler<bool>> DirectTelegramNotify(DirectTelegramNotifyRequestModel model);
}