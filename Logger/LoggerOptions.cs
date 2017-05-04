using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Providers;

namespace Logger
{
    public class LoggerOptions
    {
        public LoggerOptions(IDateTimeProvider dateTimeProvider, Func<string, LogLevel, Exception, DateTimeOffset, Type, string> logMessageComposer)
        {
            if (dateTimeProvider == null)
            {
                throw new ArgumentNullException(nameof(dateTimeProvider));
            }

            DateTimeProvider = dateTimeProvider;

            if (logMessageComposer == null)
            {
                throw new ArgumentNullException(nameof(logMessageComposer));
            }

            LogMessageComposer = logMessageComposer;
        }


        public IDateTimeProvider DateTimeProvider { get; }

        public Func<string, LogLevel, Exception, DateTimeOffset, Type, string> LogMessageComposer { get; }
    }
}
