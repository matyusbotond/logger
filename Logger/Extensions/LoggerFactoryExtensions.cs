using System.IO;
using Logger.ConsoleLogger;
using Logger.FileLogger;
using Logger.StreamLogger;

namespace Logger.Extensions
{
    public static class LoggerFactoryExtensions
    {
        public static LoggerFactory AddConsole(this LoggerFactory loggerFactory, ConsoleLoggerOptions options = null)
        {
            if (options == null)
            {
                options = ConsoleLoggerOptions.DeafultOptions;
            }

            loggerFactory.AddProvider(new ConsoleLoggerProvider(options));

            return loggerFactory;
        }

        public static LoggerFactory AddStream(this LoggerFactory loggerFactory, Stream stream, StreamLoggerOptions options = null)
        {
            if (options == null)
            {
                options = StreamLoggerOptions.DeafultOptions;
            }

            loggerFactory.AddProvider(new StreamLoggerProvider(stream, options));

            return loggerFactory;
        }

        public static LoggerFactory AddFile(this LoggerFactory loggerFactory, FileLoggerOptions options = null)
        {
            if (options == null)
            {
                options = FileLoggerOptions.DeafultOptions;
            }

            loggerFactory.AddProvider(new FileLoggerProvider(options));

            return loggerFactory;
        }
    }
}
