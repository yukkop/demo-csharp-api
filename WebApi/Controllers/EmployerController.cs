using Logic.Logic.Interface;
using logic.Model.Dto.Bundles;
using logic.Model.Dto.Employee;
using Logic.Model.Dto.Employer;
using Logic.Model.Result.Shared;
using Logic.Model.Result.Shared.Obsolete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/employer")]
public class EmployerController: BaseController<IEmployerLogic>
{ 
    public EmployerController(ILogger<EventController> logger, IEmployerLogic logic, IHttpContextAccessor context) : base(logger, logic, context)
    {
    }

    [HttpGet("list")]
    public async Task<ActionResult<IHandler<EmployerResponseModel>>> GetAll()
    {
        return await _logic.GetAll() switch {
            List<EmployerResponseModel> list => Ok(list),
            ListException<EmployerResponseModel> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.Add")
        };
    }
    
    [HttpPost()]
    public async Task<ActionResult<IHandler<bool>>> Add(AddEmployerRequestModel model)
    {
        return await _logic.Add(model) switch {
            Handler<bool> boolean => Ok(boolean.ToString()),
            HandlerException<bool> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.Add")
        };
    }
    
    [HttpPost("{id:guid}/create-bundle-on-{count:int}-user-limit")]
    public async Task<ActionResult<IHandler<bool>>> CreateBundle(Guid id, int count)
    {
        return await _logic.CreateBundle(id, count) switch
        {
            Handler<bool> boolean => Ok(boolean.ToString()),
            HandlerException<bool> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.CreateBundle")
        };
    }

    [HttpGet("{id:guid}/bundles")]
    public async Task<ActionResult<IHandler<bool>>> GetBundles(Guid id)
    {

        return await _logic.GetBundles(id) switch
        {
            List<BundleResponseModel> list => Ok(list.Unwrap()),
            ListException<BundleResponseModel> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.GetBundles")
        };
    }

    [HttpGet("{id:guid}/employee-accesses")]
    public async Task<ActionResult<IList<EmployeeAccessRequestModel>>> GetEmployeeAccesses(Guid id, [FromQuery] GetEmployeeFilter filter)
    {

        return await _logic.GetEmployeeAccesses(id, filter) switch
        {
            List<EmployeeAccessRequestModel> list => Ok(list.Unwrap()),
            ListException<EmployeeAccessRequestModel> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.GetEmployeeAccesses")
        };
    }
}