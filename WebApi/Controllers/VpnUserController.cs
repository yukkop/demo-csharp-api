using Microsoft.AspNetCore.Mvc;
using Logic.Model.Result.Shared;
using Logic.Logic.Interface;
using Logic.Model.Dto.VpnUser;
using Logic.Model.Dto.Payment;
using Logic.Model.Result.Shared.Obsolete;
using static Logic.Logic.VpnUserLogic;

namespace WebApi.Controllers;

[ApiController]
[Route("api/vpn-user")]
public class VpnUserController : BaseController<IVpnUserLogic>
{
    public VpnUserController(ILogger<VpnUserController> logger, IVpnUserLogic logic, IHttpContextAccessor context) : base(logger, logic, context)
    {
    }

    #region User

    [HttpGet("list")]
    public async Task<ActionResult> List([FromQuery] UserQuery query)
    {
        var result = await _logic.List(query);
        return result switch
        {
            not null when result.IsSuccessful => Ok(result.GetResult()),
            not null => Conflict(result.GetResult()),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.History(query)")
        };
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<IHandler<VpnUserResponseModel>>> Get(Guid id)
    {
        return await _logic.Get(id) switch
        {
            Handler<VpnUserResponseModel> value => Ok(value.Unwrap()),
            HandlerException<VpnUserResponseModel> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.Add(model)")
        };
    }

    [HttpGet("by-telegram/{telegramId:long}")]
    public async Task<ActionResult<IHandler<VpnUserResponseModel>>> GetByTelegramId(long telegramId)
    {
        return await _logic.GetByTelegramId(telegramId) switch
        {
            Handler<VpnUserResponseModel> value => Ok(value.Unwrap()),
            HandlerException<VpnUserResponseModel> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.Add(model)")
        };
    }

    /// <summary>
    /// Добавить пользователя <br/><br/>
    /// Add user
    /// </summary>
    /// <returns>
    /// Ok если пользователь создан <br/>
    /// Conflict если пользователь уже создан (совпадение telegram id) <br/><br/>
    /// Ok if the user is created <br/>
    /// Conflict if the user is already created (telegram id match)
    /// </returns>
    [HttpPost()]
    public async Task<ActionResult> Add(AddVpnUserRequestModel model)
    {
        var result = await _logic.Add(model);
        return result switch
        {
            not null when result.IsSuccessful => Ok(result.GetResult()),
            not null => Conflict(result.GetResult()),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.Add(query)")
        };
    }

    /// <summary>
    /// Изменить пользователя
    /// </summary>
    /// <returns></returns>
    [HttpPatch()]
    [ApiExplorerSettings(IgnoreApi = true)]
    public ActionResult UpdateUser()
    {
        // TODO update user
        throw new NotImplementedException();
    }

    #endregion

    #region Balance

    /// <summary>
    /// Изменить баланс пользователя
    /// </summary>
    /// <returns></returns>
    [HttpPatch("{id:guid}/add-to-balance/{value:int}")]
    public async Task<ActionResult> AddUserBalance(Guid id, int value)
    {
        await _logic.AddUserBalance(id, value);
        return Ok();
    }

    [HttpPatch("{id:guid}/balance/{value:int}")]
    public async Task<ActionResult> UpdateUserBalance(Guid id, int value)
    {
        await _logic.ChangeUserBalance(id, value);
        return Ok();
    }

    #endregion

    #region Region

    /// <summary>
    /// Изменить регион пользователя
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPatch("{userId:guid}/region-to/{regionId:guid}")]
    public async Task<ActionResult<Handler>> ChangeRegion(Guid userId, Guid regionId)
    {
        return await _logic.ChangeRegion(userId, regionId) switch
        {
            Handler<bool> value => Ok(value.Unwrap()),
            HandlerException<bool> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.Add(model)")
        };
    }

    #endregion

    #region Misc

    [HttpGet("{id:guid}/qr-code-config")]
    public async Task<ActionResult<string>> QrCodeConfig(Guid id)
    {
        return await _logic.QrCodeConfig(id) switch
        {
            Handler<byte[]> value => File(value, "image/jpeg"),
            HandlerException<byte[]> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.QrCodeConfig(id)")
        };
    }

    [HttpGet("{id:guid}/text-config")]
    public async Task<ActionResult<string>> TextConfig(Guid id)
    {
        return await _logic.TextConfig(id) switch
        {
            Handler<string> value => Ok(value.Unwrap()),
            HandlerException<string> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.TextConfig()")
        };
    }

    /// <summary>
    /// Оновить сертификат пользователя
    /// </summary>
    /// <returns></returns>
    [HttpPatch("{id:guid}/update-certificate")]
    public async Task<ActionResult<IHandler<bool>>> UserUpdateCertificate(Guid id)
    {
        return await _logic.UserUpdateCertificate(id) switch
        {
            Handler<bool> boolean => Ok(boolean.ToString()),
            HandlerException<bool> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.UserUpdateCertificate()")
        };
    }

    /// <summary>
    /// Использовать бесплатный период
    /// </summary>
    /// <returns></returns>
    [HttpPatch("{id:guid}/use-free-period")]
    public async Task<ActionResult<IHandler<bool>>> UseFreePeriod(Guid id)
    {
        return await _logic.UseFreePeriod(id) switch
        {
            Handler<bool> value => Ok(value.ToString()),
            HandlerException<bool> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.UseFreePeriod()")
        };
    }

    #endregion

    /// <summary>
    /// Удалить пользователя
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
        return Ok(await _logic.Delete(id));
    }

    [HttpGet("{id:guid}/payment/history")]
    public async Task<ActionResult<IList<PaymentUserHistoryItemModel>>> GetPaymentHistory(Guid id) {
        return await _logic.GetPaymentHistory(id) switch
        {
            List<PaymentUserHistoryItemModel> list => Ok(list),
            ListException<PaymentUserHistoryItemModel> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.GetPaymentHistory()")
        };
    }

    [HttpGet("simple-search")]
    public async Task<ActionResult<IList<VpnUserResponseModel>>> SimpleSearch([FromQuery] string searchTerm) {
        return await _logic.SimpleSearch(searchTerm) switch {
            List<VpnUserResponseModel> list => Ok(list),
            ListException<VpnUserResponseModel> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.SimpleSearch()")
        };
    }
    
    [HttpPut("{id:guid}/employee-code/{code:guid}")]
    public async Task<ActionResult<IHandler<bool>>> ConnectToEmployer(Guid id, Guid code)
    {
        return await _logic.ConnectToEmployer(id, code) switch {
            Handler<bool> answer => Ok(answer.Unwrap()),
            HandlerException<bool> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.ConnectToEmployer()")
        };
    }

    [HttpGet("{id:guid}/employed")]
    public async Task<ActionResult<IHandler<bool>>> IsEmployed(Guid id)
    {
        return await _logic.IsEmployed(id) switch {
            Handler<bool> answer => Ok(answer.Unwrap()),
            HandlerException<bool> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.IsEmployed()")
        };
    }
    
    [HttpGet("by-telegram/{telegramId:long}/exist")]
    public async Task<ActionResult<IHandler<bool>>> IsExist(long telegramId)
    {
        return await _logic.IsExist(telegramId) switch {
            Handler<bool> answer => Ok(answer.Unwrap()),
            HandlerException<bool> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.IsEmployed()")
        };
    }
    
    
    [Obsolete("Do not use this method")]
    [HttpPost("decrease-balances-and-update-time")]
    public async Task<ActionResult<IHandler<bool>>> DecreaseBalancesAndUpdateTime()
    {
        return await _logic.DecreaseBalancesAndUpdateTime() switch {
            Handler<bool> answer => Ok(answer.Unwrap()),
            HandlerException<bool> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.DecreaseBalancesAndUpdateTime()")
        };
    }
}