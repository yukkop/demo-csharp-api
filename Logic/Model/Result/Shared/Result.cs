using System.Text.Json.Serialization;

namespace Logic.Model.Result.Shared;

public class ResultContainer<T>
{
    public string Type { get; set; } = "Message";
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Message { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public T? Result { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Error { get; set; }
}