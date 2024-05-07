using Logic.Logic.Interface;
using logic.Model.Dto.Bundles;
using logic.Model.Dto.Employee;
using Logic.Model.Result.Shared;
using Logic.Model.Result.Shared.Obsolete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/bundle")]
public class BundleController: BaseController<IBundleLogic>
{
    public BundleController(ILogger<EventController> logger, IBundleLogic logic, IHttpContextAccessor context) : base(logger, logic, context)
    {
    }
    
    [HttpGet("{id:guid}/accesses")]
    public async Task<ActionResult<IList<EmployeeAccessRequestModel>>> GetEmployeeAccesses(Guid id, [FromQuery] GetEmployeeFilter filter)
    {
        return await _logic.GetEmployeeAccesses(id, filter) switch
        {
            List<EmployeeAccessRequestModel> list => Ok(list.Unwrap()),
            ListException<EmployeeAccessRequestModel> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.GetEmployeeAccesses")
        };
    }
    
    [Obsolete("Do not use it instead")]
    [HttpGet("decrease-balances-and-update-time")]
    public async Task<ActionResult<IList<bool>>> DecreaseBalancesAndUpdateTime()
    {
        return await _logic.DecreaseBalancesAndUpdateTime() switch
        {
            Handler<bool> value => Ok(value.ToString()),
            HandlerException<bool> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.GetEmployeeAccesses")
        };
    }
}