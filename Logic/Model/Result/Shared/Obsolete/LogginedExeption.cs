using Microsoft.Extensions.Logging;
// ReSharper disable All

namespace Logic.Model.Result.Shared.Obsolete;

public enum LogType {
    Error,
    Critical,
    Warning
}

[Obsolete("Use HandlerResult<T> instead")]
public class LogginedExeption: Exception
{
    
    public LogginedExeption(ILogger logger)
    {
        logger.LogError("HANDLER: empty exeption");
    }

    public LogginedExeption(ILogger logger, string message)
        : base(message)
    {
        logger.LogError($"HANDLER: {message}");
    }

    public LogginedExeption(ILogger logger, string message, LogType type)
        : base(message)
    {
        switch (type)
        {
            case LogType.Error:
                logger.LogError($"HANDLER: {message}");
                break;
            case LogType.Critical:
                logger.LogCritical($"HANDLER: {message}");
                break;
            case LogType.Warning:
                logger.LogWarning($"HANDLER: {message}");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    public LogginedExeption(ILogger logger, string message, Exception innerException)
        : base(message, innerException)
    {
        logger.LogError($"HANDLER: {message}");
    }
}