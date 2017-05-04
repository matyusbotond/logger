using System;
using System.Threading.Tasks;

namespace Logger.Extensions
{
    public static class LoggerExtensions
    {
        public static void LogDebug(this ILogger logger, string message)
        {
            logger.Log(LogLevel.Debug, null, message);
        }

        public static void LogInfo(this ILogger logger, string message)
        {
            logger.Log(LogLevel.Info, null, message);
        }

        public static void LogError(this ILogger logger, string message)
        {
            logger.Log(LogLevel.Error, null, message);
        }

        public static void LogError(this ILogger logger, Exception exception, string message = null)
        {
            logger.Log(LogLevel.Error, exception, message);
        }

        public static Task LogDebugAsync(this ILogger logger, string message)
        {
            return Task.Run(() => logger.LogDebug(message));
        }

        public static Task LogInfoAsync(this ILogger logger, string message)
        {
            return Task.Run(() => logger.LogInfo(message));
        }

        public static Task LogErrorAsync(this ILogger logger, string message)
        {
            return Task.Run(() => logger.LogError(message));
        }

        public static Task LogErrorAsync(this ILogger logger, Exception exception, string message = null)
        {
            return Task.Run(() => logger.LogError(exception, message));
        }
    }
}
