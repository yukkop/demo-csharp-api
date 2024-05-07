using Microsoft.AspNetCore.Mvc;
using Logic.Logic.Interface;

namespace WebApi.Controllers;

[ApiController]
[Route("regions")]
public class BaseController<TService> : Controller where TService : IBaseLogic
{
    protected readonly TService _logic;
    protected readonly ILogger _logger;
    protected readonly Guid _userId;

    public BaseController(ILogger logger, TService logic, IHttpContextAccessor context)
    {
        _logger = logger;
        _logic = logic;

        var user = context.HttpContext.User;
        if (user != null && user.Claims.Any())
        {
            var id = user.Identities.FirstOrDefault();
            // _userId = Convert.ToInt32(user.Identities.FirstOrDefault()
            //     ?.Claims.FirstOrDefault(x => x.Type == "sid")
            //     ?.Value);
        }

        _logic.UserId = _userId;
    }
}