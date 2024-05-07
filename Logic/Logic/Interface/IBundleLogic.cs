using logic.Model.Dto.Bundles;
using logic.Model.Dto.Employee;
using Logic.Model.Result.Shared;
using Logic.Model.Result.Shared.Obsolete;

namespace Logic.Logic.Interface;

public interface IBundleLogic: IBaseLogic
{
    public Task<IList<EmployeeAccessRequestModel>> GetEmployeeAccesses(Guid employerId, GetEmployeeFilter filter);
    public Task<IHandler<bool>> DecreaseBalancesAndUpdateTime();
}