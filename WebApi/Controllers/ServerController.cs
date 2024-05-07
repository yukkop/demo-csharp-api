using Microsoft.AspNetCore.Mvc;
using Logic.Model.Result.Shared;
using Logic.Logic.Interface;
using Logic.Model.Dto.Server;
using Logic.Model.Result.Shared.Obsolete;

namespace WebApi.Controllers;

[ApiController]
[Route("api/server")]
public class ServerController : BaseController<IServerLogic>
{
    public ServerController(ILogger<ServerController> logger, IServerLogic logic, IHttpContextAccessor context) : base(logger, logic, context)
    {
    }

    [HttpGet("list")]
    public async Task<ActionResult<IList<ServerResponseModel>>> List()
    {
        return await _logic.List() switch
        {
            IList<ServerResponseModel> list => Ok(list.Unwrap()),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.List")
        };
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> Get(Guid id)
    {
        return await _logic.Get(id) switch
        {
            Handler<ServerResponseModel> server => Ok(server.Unwrap()),
            HandlerException<ServerResponseModel> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.Get")
        };
    }

    [HttpPost()]
    public async Task<ActionResult<IHandler<bool>>> Add(AddServerRequestModel model)
    {
        return await _logic.Add(model) switch
        {
            Handler<bool> boolean => Ok(boolean.ToString()),
            HandlerException<bool> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.Add")
        };
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<IHandler<bool>>> Delete(Guid id)
    {
        return await _logic.Delete(id) switch
        {
            Handler<bool> boolean => Ok(boolean.ToString()),
            HandlerException<bool> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.Delete")
        };
    }

    [HttpPatch()]
    [ApiExplorerSettings(IgnoreApi = true)]
    public ActionResult UpdateServer()
    {
        // TODO update server
        throw new NotImplementedException();
    }
}