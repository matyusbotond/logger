using System;
using System.Collections.Generic;
using Logger.LoggerBase;
using Logger.Providers;
using Logger.ThreadSafeLoggerBase;

namespace Logger.ConsoleLogger
{
    /// <summary>
    /// Options for ConsoleLogger
    /// </summary>
    public class ConsoleLoggerOptions : ThreadSafeLoggerOptions
    {
        public int MaxLength { get; }
        public Dictionary<LogLevel, ConsoleColor> ConsoleColors { get; }

        /// <summary>
        /// ctor of options
        /// </summary>
        /// <param name="consoleColors">Colors by level</param>
        /// <param name="maxLength">Max length of custom message (exception excluded)</param>
        /// <param name="dateTimeProvider">Provide actual date for timestamp of logs</param>
        /// <param name="logFormatter">Provide a formatter for logs</param>
        public ConsoleLoggerOptions(
            Dictionary<LogLevel, ConsoleColor> consoleColors, 
            int maxLength, 
            IDateTimeProvider dateTimeProvider, 
            ILogFormatter logFormatter) : base(dateTimeProvider, logFormatter)
        {
            if (maxLength <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxLength), "MaxLength parameter must be greater then 0 character!");
            }

            MaxLength = maxLength;

            if (consoleColors == null)
            {
                throw new ArgumentNullException(nameof(consoleColors));
            }

            ConsoleColors = consoleColors;
        }

        /// <summary>
        /// consoleColors: Debug - gray, Info - Green, Error - red
        /// maxLength: 1000
        /// dateTimeProvider: <see cref="UtcDatetimeProvider"/>
        /// logFormatter: <see cref="SimpleLogFormatter"/>
        /// </summary>
        public static ConsoleLoggerOptions DeafultOptions { get; } = new ConsoleLoggerOptions(
            new Dictionary<LogLevel, ConsoleColor>()
            {
                {LogLevel.Debug, ConsoleColor.Gray},
                {LogLevel.Info, ConsoleColor.Green},
                {LogLevel.Error, ConsoleColor.Red},
            }, 1000, new UtcDatetimeProvider(), new SimpleLogFormatter());
    }
}
