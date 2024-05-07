using Microsoft.Extensions.Logging;
// ReSharper disable All
#pragma warning disable CS8602
#pragma warning disable CS8765

namespace Logic.Model.Result.Shared.Obsolete;

[Obsolete("Use HandlerResult<T> instead")]
public interface IHandler : IHandler<object>
{
    
}

[Obsolete("Use HandlerResult<T> instead")]
public interface IHandler<T>
{
    
}

[Obsolete("Use HandlerResult<T> instead")]
public static class HandlerExtensions 
{
    public static IHandler<T> Wrap<T>(this T obj)
    {
        return new Handler<T>(obj);
    }
    
    // TODO think about this
    public static IHandler<T> Wrap<T>(this T obj, ILogger logger, string message, Exception exception)
    {
        return new HandlerException<T>(logger, message, exception);
    }
    
    public static IHandler<T> Wrap<T>(this T obj, ILogger logger, Exception exception)
    {
        return new HandlerException<T>(logger, obj?.ToString() ?? "null", exception);
    }

    public static T Unwrap<T>(this IHandler<T> b) 
    {
        return b switch
        {
            Handler<T> boolean =>
                boolean,
            HandlerException<T> exception =>
                throw exception,
            _ => throw new InvalidOperationException("Unexpected result type from IBoolean<T>")
        };
    }
}

[Obsolete("Use HandlerResult<T> instead")]
public class HandlerException<T> : LogginedExeption, IHandler<T>
{
    public HandlerException(ILogger logger) : base(logger)
    {
    }

    public HandlerException(ILogger logger, string message) : base(logger, message)
    {
    }

    public HandlerException(ILogger logger, string message, LogType type) : base(logger, message, type)
    {
    }

    public HandlerException(ILogger logger, string message, Exception innerException) : base(logger, message, innerException)
    {
    }
}

[Obsolete("Use HandlerResult<T> instead")]
public class Handler : Handler<object>, IHandler
{
    public Handler(object value) : base(value)
    {
    }
}

[Obsolete("Use HandlerResult<T> instead")]
public class Handler<T> : IHandler<T>
{
    private T _value;

    public Handler(T value)
    {
        _value = value;
    }

    // Implicit conversion from Boolean<T> to T
    public static implicit operator T(Handler<T> b)
    {
        return b._value;
    }

    // Equality operator
    public static bool operator ==(Handler<T> b1, Handler<T> b2)
    {
        if (ReferenceEquals(b1, b2))
        {
            return true;
        }

        if (ReferenceEquals(b1, null) || ReferenceEquals(b2, null))
        {
            return false;
        }

        return b1._value.Equals(b2._value);
    }

    // Inequality operator
    public static bool operator !=(Handler<T> b1, Handler<T> b2)
    {
        return !(b1 == b2);
    }

    // Override Equals method
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Handler<T> other = (Handler<T>)obj;
        return _value.Equals(other._value);
    }

    // Override GetHashCode method
    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    public static implicit operator Handler<T>(T b)
    {
        return new Handler<T>(b);
    }

    public override string ToString()
    {
        return _value.ToString();
    }
}

