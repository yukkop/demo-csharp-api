using System.Collections;

namespace Logic.Model.Result.Shared;

public class HandlerResult: HandlerResult<object>
{
    public object Result { get; } = null;
    public Exception? Exception { get; } = null;
    public bool IsSuccessful => Exception == null;
    public string? Message { get; set; }

    public string Type
    {
        get
        {
            if (Exception is not null) return "Error";
            
            if (Result is null) return "Message";
            
            return Result switch
            {
                Pagination<object> => "Page",
                List<object> => "List",
                _ => "Model"
            };
        }
    }
    
    public ResultContainer<object> GetResult()
    {
        return new ResultContainer<object>
        {
            Error = Exception?.Message,
            Message = Message,
            Type = Type,
            Result = Result
        };
    }

    public HandlerResult(string message): base(message)
    {
        Message = message;
    }

    public HandlerResult(Exception exception): base(exception)
    {
        Exception = exception;
    }

    public static HandlerResult Success(string message) => new HandlerResult(message);
    public static HandlerResult Failure(Exception exception) => new HandlerResult(exception);
    public static HandlerResult Failure(string message) => new HandlerResult(new Exception(message: message));
}

public class HandlerResult<T>
{
    public T? Result { get; } = default(T);
    public Exception? Exception { get; } = null;
    public bool IsSuccessful => Exception == null;
    public string? Message { get; set; }

    public string Type
    {
        get
        {
            if (Exception is not null) return "Error";
            
            if (Result is null) return "Message";
            
            return Result switch
            {
                IPagination => "Page",
                IEnumerable => "List",
                _ => "Model"
            };
        }
    }
    
    public ResultContainer<T> GetResult()
    {
        return new ResultContainer<T>
        {
            Error = Exception?.Message,
            Message = Message,
            Type = Type,
            Result = Result
        };
    }

    public HandlerResult(T? result)
    {
        Result = result;
    }

    public HandlerResult(T? result, string message)
    {
        Result = result;
        Message = message;
    }

    public HandlerResult(string message)
    {
        Message = message;
    }

    public HandlerResult(Exception exception)
    {
        Exception = exception;
    }

    public HandlerResult(Exception exception, string message)
    {
        Exception = exception;
        Message = message;
    }

    public static HandlerResult<T> Success(T result) => new HandlerResult<T>(result);
    public static HandlerResult<T> Success(T result, string message) => new HandlerResult<T>(result, message);
    public static HandlerResult<T> Success(string message) => new HandlerResult<T>(message);
    public static HandlerResult<T> Failure(Exception exception) => new HandlerResult<T>(exception);
    public static HandlerResult<T> Failure(string message) => new HandlerResult<T>(new Exception(message: message), message: message);
}