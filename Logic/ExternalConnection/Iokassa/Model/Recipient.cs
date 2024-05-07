using System.Text.Json.Serialization;

namespace Logic.ExternalConnection.Iokassa.Model;

public class Recipient
{
    [JsonPropertyName("account_id")]
    public string? AccountId { get; set; }
    
    [JsonPropertyName("gateway_id")]
    public string? GatewayId { get; set; }
}