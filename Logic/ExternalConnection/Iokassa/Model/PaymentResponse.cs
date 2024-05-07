using System.Text.Json.Serialization;

namespace Logic.ExternalConnection.Iokassa.Model;

public class PaymentResponse
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    
    [JsonPropertyName("status")]
    public string? Status { get; set; }
    
    [JsonPropertyName("amount")]
    public Amount? Amount { get; set; }
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    [JsonPropertyName("recipient")]
    public Recipient? Recipient { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [JsonPropertyName("confirmation")]
    public ConfirmationResponse? Confirmation { get; set; }
    
    [JsonPropertyName("test")]
    public bool Test { get; set; }
    
    [JsonPropertyName("paid")]
    public bool Paid { get; set; }
    
    [JsonPropertyName("refundable")]
    public bool Refundable { get; set; }
    
    [JsonPropertyName("metadata")]
    public Metadata? Metadata { get; set; }
}

public class ConfirmationResponse
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    
    [JsonPropertyName("confirmation_url")]
    public string? ConfirmationUrl { get; set; }
}

public class Metadata
{
}
