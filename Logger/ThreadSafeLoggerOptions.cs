using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Providers;

namespace Logger
{
    public class ThreadSafeLoggerOptions : LoggerOptions
    {
        internal object SyncObject;

        public ThreadSafeLoggerOptions(IDateTimeProvider dateTimeProvider, Func<string, LogLevel, Exception, DateTimeOffset, Type, string> logMessageComposer) : base(dateTimeProvider, logMessageComposer)
        {
            SyncObject = new object();
        }
    }
}
