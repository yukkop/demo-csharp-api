using System.Collections;
using Microsoft.Extensions.Logging;
// ReSharper disable All

namespace Logic.Model.Result.Shared.Obsolete;

[Obsolete("Use HandlerResult<T> instead")]
public static class ListExtensions
{
    public static List<T> Unwrap<T>(this IList<T> l)
    {
        return l switch
        {
            List<T> list =>
                list,
            ListException<T> exception =>
                throw exception,
            _ => throw new InvalidOperationException("Unexpected result type from IList")
        };
    }
}

[Obsolete("Use HandlerResult<T> instead")]
public class UnmatchedListException : Exception
{
    public UnmatchedListException(ILogger logger)
    {
        logger.LogError("HANDLER: empty exeption");
    }

    public UnmatchedListException(ILogger logger, string message)
        : base(message)
    {
        logger.LogError($"HANDLER: {message}");
    }

    public UnmatchedListException(ILogger logger, string message, LogType type)
        : base(message)
    {
        if (type == LogType.Error)
            logger.LogError($"HANDLER: {message}");
        if (type == LogType.Critical)
            logger.LogCritical($"HANDLER: {message}");
    }

    public UnmatchedListException(ILogger logger, string message, Exception innerException)
        : base(message, innerException)
    {
        logger.LogError($"HANDLER: {message}");
    }
}

[Obsolete("Use HandlerResult<T> instead")]
public class ListException<T> : Exception, IList<T>
{
    public ListException(ILogger logger)
    {
        logger.LogError("HANDLER: empty exeption");
    }

    public ListException(ILogger logger, string message): base(message)
    {
        logger.LogError($"HANDLER: {message}");
    }

    public ListException(ILogger logger, string message, LogType type): base(message)
    {
        if (type == LogType.Error)
            logger.LogError($"HANDLER: {message}");
        if (type == LogType.Critical)
            logger.LogCritical($"HANDLER: {message}");
    }

    public ListException(ILogger logger, string message, Exception innerException): base(message, innerException)
    {
        logger.LogError($"HANDLER: {message}");
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        throw this;
    }

    public IEnumerator GetEnumerator()
    {
        throw this;
    }

    public void CopyTo(Array array, int index)
    {
        throw this;
    }

    public bool Remove(T item)
    {
        throw this;
    }

    public int Count => throw this;
    public bool IsSynchronized => throw this;
    public object SyncRoot => throw this;

    public int Add(object? value)
    {
        throw this;
    }

    public void Add(T item)
    {
        throw this;
    }

    public void Clear()
    {
        throw this;
    }

    public bool Contains(T item)
    {
        throw this;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw this;
    }

    public bool Contains(object? value)
    {
        throw this;
    }

    public int IndexOf(object? value)
    {
        throw this;
    }

    public void Insert(int index, object? value)
    {
        throw this;
    }

    public void Remove(object? value)
    {
        throw this;
    }

    public int IndexOf(T item)
    {
        throw this;
    }

    public void Insert(int index, T item)
    {
        throw this;
    }

    public void RemoveAt(int index)
    {
        throw this;
    }

    T IList<T>.this[int index]
    {
        get => throw this;
        set => throw this;
    }

    public bool IsFixedSize => throw this;
    public bool IsReadOnly => throw this;

    public object? this[int index]
    {
        get => throw this;
        set => throw this;
    }
}