using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Logic.ExternalConnection.Iokassa.Model;
using Logic.Logic;
using Logic.Logic.Interface;
using logic.Model.Dto;
using Logic.Model.Dto.Payment;
using Logic.Model.Result.Shared;
using Logic.Model.Dto.VpnUser;
using Logic.Model.Result.Shared.Obsolete;

namespace WebApi.Controllers;

[ApiController]
[Route("api/payment")]
public class PaymentController: BaseController<IPaymentLogic>
{
    public PaymentController(ILogger<PaymentController> logger, IPaymentLogic logic, IHttpContextAccessor context) : base(logger, logic, context)
    {
    }
     
   [HttpPost("create-paykeeper-payment")]
    public async Task<ActionResult<IHandler<bool>>> CreatePayKeeperPayment(CreatePaykeeperPaymentRequestModel model)
    {
        return await _logic.CreatePayKeeperPayment(model) switch
        {
            Handler<string> value => Json(new { ConfirmationUrl = value.ToString()}),
            HandlerException<string> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.CreatePayKeeperPayment(model)")
        };
    }
    
   [HttpPost("create-yookassa-payment")]
    public async Task<ActionResult<IHandler<bool>>> CreateYookassaPayment(CreateYookassaPaymentRequestModel model)
    {
        return await _logic.CreateYookassaPayment(model) switch
        {
            Handler<string> value => Json(new { ConfirmationUrl = value.ToString()}),
            HandlerException<string> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.CreateYookassaPayment(model)")
        };
    }
    
   [Obsolete("Use create-yookassa-payment instead")]
   [HttpPost("create-iokassa-payment")]
    public async Task<ActionResult<IHandler<bool>>> CreateIokassaPayment(CreatePaymentRequestModel model)
    {
        return await _logic.CreateIokassaPayment(model) switch
        {
            Handler<string> value => Json(new { ConfirmationUrl = value.ToString()}),
            HandlerException<string> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.CreateIokassaPayment(model)")
        };
    }
    
    // TODO Idempotent Key Header
   [Obsolete("Use handle-yookassa-notification instead")]
   [HttpPost("handle-iokassa-notification")]
    public async Task<ActionResult<IHandler<bool>>> HandleIokassaNotification(PaymentNotification model)
    {
        return await _logic.HandleIokassaPayment(model) switch
        {
            Handler<bool> value => Ok(value.ToString()),
            HandlerException<bool> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.HandleIokassaPayment(model)")
        };
    }
    
   [HttpPost("handle-yookassa-notification")]
    public async Task<ActionResult<IHandler<bool>>> HandleYookassaNotification(PaymentNotification model)
    {
        return await _logic.HandleIokassaPayment(model) switch
        {
            Handler<bool> value => Ok(value.ToString()),
            HandlerException<bool> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.HandleIokassaPayment(model)")
        };
    }
    
   [HttpPost("paykeeper-status-check")]
    public async Task<ActionResult<IHandler<bool>>> PaykeeperStatusCheck()
    {
        return await _logic.PaykeeperStatusCheck() switch
        {
            Handler<bool> value => Ok(value.ToString()),
            HandlerException<bool> exception => Conflict(exception),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.PaykeeperStatusCheck()")
        };
    }
    
    [Obsolete("Useless")]
    [HttpPost("handle-paykeeper-notification")]
    public async Task<ActionResult<IHandler<bool>>> HandlePaykeeperNotification()
    {
        // Log headers
        foreach (var header in Request.Headers)
        {
            Console.WriteLine($"{header.Key}: {header.Value}");
        }

        // Log body
        using (var reader = new StreamReader(Request.Body))
        {
            var body = await reader.ReadToEndAsync();
            Console.WriteLine("Body:");
            Console.WriteLine(body);
        }

        return Ok(true.Wrap());
    }
    
    /// <summary>
    /// filter может принимать операторы ! и & а также поля test и paid всё должно быть разделенно пробелами пример filter='! paid' или filter='test & ! paid'
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    [HttpGet("history")]
    public async Task<ActionResult> History([FromQuery] PaymentLogic.HistoryQuery query)
    {
        var result = await _logic.History(query);
        return result switch
        {
            not null when result.IsSuccessful => Ok(result.GetResult()),
            not null => Conflict(result.GetResult()),
            _ => throw new InvalidOperationException("Unexpected result type from _logic.History(query)")
        };
    }
}