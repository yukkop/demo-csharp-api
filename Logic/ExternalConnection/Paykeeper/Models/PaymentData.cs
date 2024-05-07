using System.Text.Json.Serialization;
namespace Logic.ExternalConnection.Paykeeper.Models;

public class PaymentData
{
    [JsonPropertyName("pay_amount")]
    public string PayAmount { get; set; }

    [JsonPropertyName("clientid")]
    public string ClientId { get; set; }

    [JsonPropertyName("orderid")]
    public string OrderId { get; set; }

    [JsonPropertyName("client_email")]
    public string ClientEmail { get; set; }

    [JsonPropertyName("service_name")]
    public string ServiceName { get; set; }

    [JsonPropertyName("client_phone")]
    public string ClientPhone { get; set; }

    [JsonPropertyName("token")]
    public string Token { get; set; }
}
