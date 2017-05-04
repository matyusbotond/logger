using System;

namespace Logger.ConsoleLogger
{
    public class ConsoleLogger<TSource> : ThreadSafeLoggerBase<TSource>
    {
        private readonly ConsoleLoggerOptions _options;

        public ConsoleLogger(ConsoleLoggerOptions options) : base(options)
        {
            _options = options;
        }

        protected override void LogImpl(LogLevel logLevel, Exception exception, string message, DateTimeOffset dateTimeOffset)
        {
            if (message == null && exception == null)
            {
                throw new ArgumentNullException("Message or exception parameter must be not null!");
            }

            if (message != null && message.Length > _options.MaxLength)
            {
                throw new ArgumentOutOfRangeException(nameof(message), $"The message must be lower than {_options.MaxLength} character!");
            }

            SetConsoleColors(logLevel);

            Console.WriteLine(_options.LogMessageComposer(message, logLevel, exception, dateTimeOffset, Source));

            Console.ResetColor();
        }

        protected void SetConsoleColors(LogLevel logLevel)
        {
            if (_options.ConsoleColors.ContainsKey(logLevel))
            {
                Console.ForegroundColor = _options.ConsoleColors[logLevel];
            }
        }
    }
}
