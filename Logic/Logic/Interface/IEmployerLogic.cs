using logic.Model.Dto.Bundles;
using logic.Model.Dto.Employee;
using Logic.Model.Dto.Employer;
using Logic.Model.Result.Shared;
using Logic.Model.Result.Shared.Obsolete;

namespace Logic.Logic.Interface;

public interface IEmployerLogic: IBaseLogic
{
    public Task<IList<EmployerResponseModel>> GetAll();
    public Task<IHandler<bool>> Add(AddEmployerRequestModel model);
    public Task<IHandler<bool>> CreateBundle(Guid employerId, int employeesCount);
    public Task<IList<BundleResponseModel>> GetBundles(Guid employerId);
    public Task<IList<EmployeeAccessRequestModel>> GetEmployeeAccesses(Guid employerId, GetEmployeeFilter filter);
}