using Logic.Enum;
using Microsoft.AspNetCore.Mvc;
using Logic.Model.Result.Shared;
using Logic.Logic.Interface;
using Logic.Model.Dto;
using Logic.Model.Dto.User;
using Logic.Model.Result.Shared.Obsolete;
using Logic.Model.Result.UserLogic;

namespace WebApi.Controllers;

[ApiController]
[Route("api/vpn-user")]
public class UserController : BaseController<IUserLogic>
{
    public UserController(ILogger<UserController> logger, IUserLogic logic, IHttpContextAccessor context) : base(logger, logic, context)
    {
    }

    [HttpGet("token")]
    public async Task<IActionResult> GetToken([FromQuery] LoginRequestModel model)
    {
        return await _logic.GetToken(model) switch
        {
            GetTockenJWTTokenResult tocken => Ok(tocken.Unwrap()),
            GetTockenUnauthorizeResult unauthoriza => Unauthorized(),
            GetTockenExceptionResult exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.GetToken")
        };
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestModel model)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _logic.Register(model, UserRoleEnum.VpnUser));
        }

        return BadRequest(ModelState);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _logic.GetAll());
    }
}