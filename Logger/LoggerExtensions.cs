using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
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

        public static void LogError(this ILogger logger, Exception exception, string message)
        {
            logger.Log(LogLevel.Error, exception, message);
        }
    }
}
