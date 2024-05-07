using System.Text.Json.Serialization;

namespace Logic.ExternalConnection.Iokassa.Model;

public class Amount
{
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }
}