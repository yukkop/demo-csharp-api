using Logic.Model.Result.Shared;
using Logic.Model.Dto.Region;
using Logic.Model.Result.Shared.Obsolete;

namespace Logic.Logic.Interface;

public interface IRegionLogic: IBaseLogic
{
    public Task<IHandler<bool>> Delete(Guid id);
    public Task<IHandler<bool>> Add(AddRegionRequestModel model);
    public Task<IList<RegionResponseModel>> List();
    public Task<IHandler<RegionResponseModel>> Get(Guid id);
}