using System;
using Logger.LoggerBase;
using Logger.Providers;

namespace Logger.ThreadSafeLoggerBase
{
    public abstract class ThreadSafeLoggerOptions : LoggerOptions
    {
        internal object SyncObject;

        protected ThreadSafeLoggerOptions(IDateTimeProvider dateTimeProvider, ILogFormatter logFormatter) : base(dateTimeProvider, logFormatter)
        {
            SyncObject = new object();
        }
    }
}
