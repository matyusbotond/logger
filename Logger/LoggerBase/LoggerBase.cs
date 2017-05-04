using System;

namespace Logger.LoggerBase
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
            LogImpl(CreateLog(logLevel, exception,message));
        }

        protected virtual Log CreateLog(LogLevel logLevel, Exception exception, string message)
        {
            return new Log(_options.DateTimeProvider.Now, exception, message, logLevel, Source);
        }

        protected abstract void LogImpl(Log log);

        public virtual void Dispose()
        {
        }
    }
}
