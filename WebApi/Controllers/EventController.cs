using Microsoft.AspNetCore.Mvc;
using Logic.Logic.Interface;
using Logic.Model.Result.Shared;
using Logic.Model.Dto;
using Logic.Model.Result.Shared.Obsolete;

namespace WebApi.Controllers;

[ApiController]
[Route("api/event")]
public class EventController: BaseController<IEventLogic>
{
    public EventController(ILogger<EventController> logger, IEventLogic logic, IHttpContextAccessor context) : base(logger, logic, context)
    {
    }
    
   [HttpPost("direct-telegram-notify")]
   // [HandledAuthorize]
    public async Task<ActionResult<IHandler<bool>>> Notify(DirectTelegramNotifyRequestModel model)
    {
        return await _logic.DirectTelegramNotify(model) switch
        {
            Handler<bool> value => Ok(value.ToString()),
            HandlerException<bool> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.DirectTelegramNotify(model)")
        };
    }

}