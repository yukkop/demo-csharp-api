using Logic.Model.Result.Shared;
using Logic.Model.Dto.Server;
using Logic.Model.Result.Shared.Obsolete;

namespace Logic.Logic.Interface;

public interface IServerLogic: IBaseLogic
{
    public Task<IHandler<bool>> Add(AddServerRequestModel model);
    public Task<IList<ServerResponseModel>> List();
    public Task<IHandler<ServerResponseModel>> Get(Guid id);

    public Task<IHandler<bool>> Delete(Guid id);
}