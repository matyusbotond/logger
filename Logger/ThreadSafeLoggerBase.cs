using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public abstract class ThreadSafeLoggerBase<TSource> : LoggerBase<TSource>
    {
        private readonly ThreadSafeLoggerOptions _options;

        protected ThreadSafeLoggerBase(ThreadSafeLoggerOptions options) : base(options)
        {
            _options = options;
        }

        public override void Log(LogLevel logLevel, Exception exception, string message)
        {
            var now = _options.DateTimeProvider.Now;

            lock (_options.SyncObject)
            {
                LogImpl(logLevel, exception, message, now);
            }
        }
    }
}
