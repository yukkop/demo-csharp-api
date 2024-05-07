using System.Text.Json.Serialization;

namespace Logic.ExternalConnection.Iokassa.Model;
public class PaymentRequest
{
    [JsonPropertyName("amount")]
    public Amount? Amount { get; set; }

    [JsonPropertyName("capture")]
    public bool Capture { get; set; }

    [JsonPropertyName("confirmation")]
    public ConfirmationRequest? Confirmation { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}

public class ConfirmationRequest
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("return_url")]
    public string? ReturnUrl { get; set; }
}