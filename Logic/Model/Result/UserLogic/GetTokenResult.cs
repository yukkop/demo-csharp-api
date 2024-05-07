using Logic.Model.Result.Shared;
using Logic.Model.Result.Shared.Obsolete;
using Microsoft.Extensions.Logging;

namespace Logic.Model.Result.UserLogic;
public interface IGetTockenResult
{

}

public class GetTockenJWTTokenResult : Handler<string>, IGetTockenResult
{
    public GetTockenJWTTokenResult(string value) : base(value)
    {
    }
}

public class GetTockenUnauthorizeResult : IGetTockenResult
{
}

public class GetTockenExceptionResult : LogginedExeption, IGetTockenResult
{
    public GetTockenExceptionResult(ILogger logger) : base(logger)
    {
    }

    public GetTockenExceptionResult(ILogger logger, string message) : base(logger, message)
    {
    }

    public GetTockenExceptionResult(ILogger logger, string message, LogType type) : base(logger, message, type)
    {
    }

    public GetTockenExceptionResult(ILogger logger, string message, Exception innerException) : base(logger, message, innerException)
    {
    }
}