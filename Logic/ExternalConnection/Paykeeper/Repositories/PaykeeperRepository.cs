using System.Globalization;
using System.Net.Http.Headers;
using System.Text;
using Flurl.Http;
using Logic.ExternalConnection.Paykeeper.Models;
using Logic.Model.Result.Shared;
using Logic.Model.Result.Shared.Obsolete;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Logic.ExternalConnection.Paykeeper.Repositories;

public class InvoiceResponse
{
    [JsonProperty("id")] public string Id { get; set; }

    [JsonProperty("user_id")] public string UserId { get; set; }

    [JsonProperty("status")] public string Status { get; set; }

    [JsonProperty("pay_amount")] public string PayAmount { get; set; }

    [JsonProperty("clientid")] public string ClientId { get; set; }

    [JsonProperty("orderid")] public string OrderId { get; set; }

    [JsonProperty("paymentid")] public string PaymentId { get; set; }

    [JsonProperty("service_name")] public string ServiceName { get; set; }

    [JsonProperty("client_email")] public string ClientEmail { get; set; }

    [JsonProperty("client_phone")] public string ClientPhone { get; set; }

    [JsonProperty("expiry_datetime")] public DateTime? ExpiryDatetime { get; set; }

    [JsonProperty("created_datetime")] public DateTime? CreatedDatetime { get; set; }

    [JsonProperty("paid_datetime")] public DateTime? PaidDatetime { get; set; }
}

public class PaymentInfo
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("pay_amount")]
    public string PayAmount { get; set; }

    [JsonProperty("clientid")]
    public string ClientId { get; set; }

    [JsonProperty("orderid")]
    public string OrderId { get; set; }

    [JsonProperty("payment_system_id")]
    public string PaymentSystemId { get; set; }

    [JsonProperty("unique_id")]
    public string UniqueId { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("repeat_counter")]
    public string RepeatCounter { get; set; }

    [JsonProperty("pending_datetime")]
    public DateTime? PendingDateTime { get; set; }

    [JsonProperty("obtain_datetime")]
    public DateTime? ObtainDateTime { get; set; }

    [JsonProperty("success_datetime")]
    public DateTime? SuccessDateTime { get; set; }
}

public class PaykeeperRepository
{
    readonly string _user = "yukkop";
    readonly string _password = "#h6f%m9L7@!G";

    private readonly IConfiguration _configuration;
    private readonly string _paykeeperAuth;
    private readonly string _paykeeperServer;

    public PaykeeperRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _paykeeperServer = configuration.GetValue<string>("Paykeeper:Server");
        _paykeeperAuth =
            $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{configuration.GetValue<string>("Paykeeper:Login")}:{configuration.GetValue<string>("Paykeeper:Password")}"))}";
    }

    public async Task<IHandler<(string, string)>> CreatePayment(decimal value, string userId, Guid orderId)
    {
        var cli =
            new FlurlClient(_paykeeperServer)
                .WithHeader("Authorization",
                    _paykeeperAuth);

        var tokenResponse = await cli.Request("info/settings/token/")
            .GetAsync()
            .ReceiveString();

        var tokenResponseDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(tokenResponse);

        if (!tokenResponseDict.TryGetValue("token", out var token))
        {
            throw new Exception("Token not received");
        }

        var responseString = await cli.Request("change/invoice/preview/")
            .WithHeader("Content-Type", "application/x-www-form-urlencoded")
            .PostUrlEncodedAsync(new
            {
                token, pay_amount = value.ToString(CultureInfo.InvariantCulture), orderid = orderId.ToString(),
                service_name = "vpn-services", clientid = userId.ToString()
            })
            .ReceiveString();

        var responseStringDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);

        if (!responseStringDict.TryGetValue("invoice_id", out var invoiceId))
        {
            throw new Exception("Invoice ID not received");
        }

        var paymentLink = $"{_paykeeperServer}/bill/{invoiceId}/";
        return (paymentLink, invoiceId).Wrap();
    }
    
    public async Task<IList<PaymentInfo>> PaymentInfo(Guid orderId)
    {
        var cli =
            new FlurlClient(_paykeeperServer)
                .WithHeader("Authorization",
                    _paykeeperAuth);
        
        // curl -X GET -H "Content-Type: application/x-www-form-urlencoded" -H "Authorization: Basic $(echo -n 'yukkop:#h6f%m9L7@!G' | base64)" "https://helpexcel.server.paykeeper.ru/info/payments/search/?query=5a3a*&beg_date=2016-01-01&end_date=2023-06-15"
        var responseString = await cli.Request("info/payments/search/")
                .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                .SetQueryParam("query", orderId)
                .SetQueryParam("beg_date", DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd"))
                .SetQueryParam("end_date", DateTime.Now.ToString("yyyy-MM-dd"))
                .GetAsync()
                .ReceiveString();
        
        if (string.IsNullOrEmpty(responseString))
        {
            return new List<PaymentInfo>();
        }
        var paymentInfo = JsonConvert.DeserializeObject<PaymentInfo[]>(responseString).ToList();
        return paymentInfo;
    }

    public async Task<IHandler<InvoiceResponse>> InvoiceInfo(string invoiceId)
    {
        var cli =
            new FlurlClient(_paykeeperServer)
                .WithHeader("Authorization",
                    _paykeeperAuth);

        var responseString = await cli.Request("info/invoice/byid/")
            .WithHeader("Content-Type", "application/x-www-form-urlencoded")
            .SetQueryParam("id", invoiceId)
            .PostUrlEncodedAsync(new
            {
                id = invoiceId
            })
            .ReceiveString();

        var invoiceResponse = JsonConvert.DeserializeObject<InvoiceResponse>(responseString);

        return invoiceResponse.Wrap();
    }
}