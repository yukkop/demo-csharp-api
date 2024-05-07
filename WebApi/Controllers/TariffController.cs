using Microsoft.AspNetCore.Mvc;
using Logic.Logic.Interface;
using Logic.Model.Result.Shared;
using logic.Model.Dto.Tariff;
using Logic.Model.Result.Shared.Obsolete;

namespace WebApi.Controllers;

[ApiController]
[Route("api/tariff")]
public class TariffController : BaseController<ITariffLogic>
{
    public TariffController(ILogger<TariffController> logger, ITariffLogic logic, IHttpContextAccessor context)
        : base(logger, logic, context)
    {
    }

    [HttpPost()]
    public async Task<IActionResult> Add(AddTariffRequestModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _logic.Add(model);

        return result switch
        {
            not null when result.IsSuccessful => Ok(result.GetResult()),
            not null => Conflict(result.GetResult()),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.Add")
        };
    }

    [HttpGet("period-units")]
    public async Task<IActionResult> GetPeriodUnits()
    {
        var result = await _logic.GetPeriodUnits();

        return result switch
        {
            not null when result.IsSuccessful => Ok(result.Result),
            not null => Conflict(result.Exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.GetPeriodUnits")
        };
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _logic.GetAll();

        return result switch
        {
            not null when result.IsSuccessful => Ok(result.Result),
            not null => Conflict(result.Exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.GetAll")
        };
    }

    [HttpGet("all-personal")]
    public async Task<IActionResult> GetAllPersonal()
    {
        var result = await _logic.GetAllPersonal();

        return result switch
        {
            not null when result.IsSuccessful => Ok(result.Result),
            not null => Conflict(result.Exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.GetAllPersonal")
        };
    }
}