using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.ConsoleLogger;
using Logger.FileLogger;
using Logger.StreamLogger;

namespace Logger
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
