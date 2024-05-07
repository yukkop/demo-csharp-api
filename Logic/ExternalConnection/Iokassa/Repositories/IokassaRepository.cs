using System.Text;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Logic.ExternalConnection.Iokassa.Model;
using Logic.Model.Result.Shared;
using Logic.Model.Result.Shared.Obsolete;

namespace Logic.ExternalConnection.Iokassa.Repositories;

public class IokassaRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _yookassaAuth;
    public IokassaRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _yookassaAuth = $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{configuration.GetValue<string>("Yookassa:ShopId")}:{configuration.GetValue<string>("Yookassa:Token")}"))}";
    }

    public async Task<IHandler<(PaymentRequest, PaymentResponse)>> CreatePayment(decimal value, string returnUrl, Guid idempotenceKey)
    {
        var cli =
            new FlurlClient("https://api.yookassa.ru/v3/")
                .WithHeader("Authorization",
                    _yookassaAuth)
                .WithHeader("Idempotence-Key",
                    idempotenceKey.ToString());
        var request = cli.Request($"payments");

        var paymentRequest = new PaymentRequest
        {
            Amount = new Amount { Value = value.ToString(), Currency = "RUB" },
            Capture = true,
            Confirmation = new ConfirmationRequest
            {
                Type = "redirect",
                ReturnUrl = returnUrl
            },
            Description = "vpn"
        };

        var paymentResponse = await request.PostJsonAsync(paymentRequest).ReceiveJson<PaymentResponse>();

        return (paymentRequest, paymentResponse).Wrap();
    }

}