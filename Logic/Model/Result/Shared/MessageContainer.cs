using System.Net.Mime;

namespace Logic.Model.Result.Shared;

[Obsolete("Use HandlerResult<T> instead")]
public class MessageContainer
{
    public MessageContainer(string text)
    {
        Message = text;
    }
    
    public static MessageContainer Success => new("Success");
    public string? Message { get; set; }
}