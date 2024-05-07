using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Logic.Model.Result.Shared;
using Logic.Logic.Interface;
using Logic.Model.Dto.Region;
using Logic.Model.Result.Shared.Obsolete;

namespace WebApi.Controllers;

[ApiController]
[Route("api/peer")]
public class PeerController: BaseController<ICertificateLogic> 
{
    public PeerController(ILogger<PeerController> logger, ICertificateLogic logic, IHttpContextAccessor context) : base(logger, logic, context)
    {
    }
    
    [Obsolete("do not use it")]
    [HttpGet("update-bytes-info")]
    public async Task<ActionResult<IList<RegionResponseModel>>> List()
    {
        return await _logic.UpdateBytesInfo() switch
        {
            Handler<bool> boolean => Ok(boolean.ToString()),
            HandlerException<bool> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.UpdateBytesInfo")
        };
    }
}