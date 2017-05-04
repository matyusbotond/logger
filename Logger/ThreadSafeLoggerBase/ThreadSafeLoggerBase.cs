using System;
using Logger.LoggerBase;

namespace Logger.ThreadSafeLoggerBase
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
            var log = CreateLog(logLevel, exception, message);

            lock (_options.SyncObject)
            {
                LogImpl(log);
            }
        }
    }
}
