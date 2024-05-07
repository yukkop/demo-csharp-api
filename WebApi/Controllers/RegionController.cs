using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Logic.Model.Result.Shared;
using Logic.Logic.Interface;
using Logic.Model.Dto.Region;
using Logic.Model.Result.Shared.Obsolete;

namespace WebApi.Controllers;

[ApiController]
[Route("api/region")]
public class RegionController: BaseController<IRegionLogic>
{
    public RegionController(ILogger<RegionController> logger, IRegionLogic logic, IHttpContextAccessor context) : base(logger, logic, context)
    {
    }
    
    [HttpGet("list")]
    public async Task<ActionResult<IList<RegionResponseModel>>> List()
    {
       return await _logic.List() switch
        {
            List<RegionResponseModel> list => Ok(list.Unwrap()),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.List")
        }; 
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<RegionResponseModel>> Get(Guid id)
    {
       return await _logic.Get(id) switch
        {
            Handler<RegionResponseModel> val => Ok(val.Unwrap()),
            HandlerException<RegionResponseModel> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.Delete")
        }; 
    }
    
    [HttpPost()]
    public async Task<ActionResult<IHandler<bool>>> Add(AddRegionRequestModel model)
    {
        return await _logic.Add(model) switch
        {
            Handler<bool> boolean => Ok(boolean.ToString()),
            HandlerException<bool> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.Add")
        };
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
       return await _logic.Delete(id) switch
        {
            Handler<bool> val => Ok(val.Unwrap()),
            HandlerException<bool> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.Delete")
        }; 
    }
}