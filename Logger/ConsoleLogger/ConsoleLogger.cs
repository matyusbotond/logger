using System;
using Logger.ThreadSafeLoggerBase;

namespace Logger.ConsoleLogger
{
    public class ConsoleLogger<TSource> : ThreadSafeLoggerBase<TSource>
    {
        private readonly ConsoleLoggerOptions _options;

        public ConsoleLogger(ConsoleLoggerOptions options) : base(options)
        {
            _options = options;
        }

        protected override void LogImpl(Log log)
        {
            if (log.Message == null && log.Exception == null)
            {
                throw new ArgumentNullException("Message or exception parameter must be not null!");
            }

            if (log.Message != null && log.Message.Length > _options.MaxLength)
            {
                throw new ArgumentOutOfRangeException(nameof(log.Message), $"The message must be lower than {_options.MaxLength} character!");
            }

            SetConsoleColors(log.Level);

            Console.WriteLine(_options.LogFormatter.Format(log));

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
