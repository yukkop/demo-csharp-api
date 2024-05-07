using System.Collections;
// ReSharper disable All

namespace Logic.Model.Result.Shared.Obsolete;

[Obsolete("Use HandlerResult<T> instead")]
public class UnmatchedCollectionException : Exception
{
    public UnmatchedCollectionException() : base(
        "Expected collection but got an exception, try to match list after using")
    {
    }

    public UnmatchedCollectionException(string message)
        : base(message)
    {
    }

    public UnmatchedCollectionException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}

[Obsolete("Use HandlerResult<T> instead")]
public class CollectionException<T> : Exception, ICollection
{
    public IEnumerator GetEnumerator()
    {
        throw new UnmatchedCollectionException();
    }

    public void CopyTo(Array array, int index)
    {
        throw new UnmatchedCollectionException();
    }

    public int Count => throw new UnmatchedCollectionException();
    public bool IsSynchronized => throw new UnmatchedCollectionException();
    public object SyncRoot => throw new UnmatchedCollectionException();
}