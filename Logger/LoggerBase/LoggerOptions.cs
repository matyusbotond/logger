using System;
using Logger.Providers;

namespace Logger.LoggerBase
{
    public class LoggerOptions
    {
        public LoggerOptions(IDateTimeProvider dateTimeProvider, ILogFormatter logFormatter)
        {
            if (dateTimeProvider == null)
            {
                throw new ArgumentNullException(nameof(dateTimeProvider));
            }

            DateTimeProvider = dateTimeProvider;

            if (logFormatter == null)
            {
                throw new ArgumentNullException(nameof(logFormatter));
            }

            LogFormatter = logFormatter;
        }


        public IDateTimeProvider DateTimeProvider { get; }

        public ILogFormatter LogFormatter { get; }
    }
}
