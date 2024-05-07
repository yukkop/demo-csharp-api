using System.Text.Json.Serialization;

namespace Logic.ExternalConnection.Iokassa.Model;

public class PaymentNotification
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("event")]
    public string? Event { get; set; }

    [JsonPropertyName("object")]
    public PaymentObject? Object { get; set; }
}

public class PaymentObject
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("amount")]
    public Amount? Amount { get; set; }

    [JsonPropertyName("income_amount")]
    public Amount? IncomeAmount { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("recipient")]
    public Recipient? Recipient { get; set; }

    [JsonPropertyName("payment_method")]
    public PaymentMethod? PaymentMethod { get; set; }

    [JsonPropertyName("captured_at")]
    public DateTime CapturedAt { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("test")]
    public bool Test { get; set; }

    [JsonPropertyName("refunded_amount")]
    public Amount? RefundedAmount { get; set; }

    [JsonPropertyName("paid")]
    public bool Paid { get; set; }

    [JsonPropertyName("refundable")]
    public bool Refundable { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }
}

public class PaymentMethod
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("saved")]
    public bool Saved { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("account_number")]
    public string? AccountNumber { get; set; }
}
