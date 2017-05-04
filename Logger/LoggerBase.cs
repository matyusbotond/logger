using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public abstract class LoggerBase<TSource> : ILogger<TSource>
    {
        private readonly LoggerOptions _options;

        public Type Source => typeof(TSource);

        protected LoggerBase(LoggerOptions options)
        {
            _options = options;
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
        }

        public virtual void Log(LogLevel logLevel, Exception exception, string message)
        {
            LogImpl(logLevel, exception,message, _options.DateTimeProvider.Now);
        }

        protected abstract void LogImpl(LogLevel logLevel, Exception exception, string message, DateTimeOffset dateTimeOffset);

        public virtual void Dispose()
        {
        }
    }
}
