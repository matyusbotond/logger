﻿using System;
using System.Collections.Generic;
using Logger.Providers;

namespace Logger.ConsoleLogger
{
    public class ConsoleLoggerOptions : ThreadSafeLoggerOptions
    {
        public int MaxLength { get; }
        public Dictionary<LogLevel, ConsoleColor> ConsoleColors { get; }

        public ConsoleLoggerOptions(
            Dictionary<LogLevel, ConsoleColor> consoleColors, 
            int maxLength, 
            IDateTimeProvider dateTimeProvider, 
            Func<string, LogLevel, Exception, DateTimeOffset, Type, string> logMessageComposer) : base(dateTimeProvider, logMessageComposer)
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

        public static ConsoleLoggerOptions DeafultOptions { get; } = new ConsoleLoggerOptions(
            new Dictionary<LogLevel, ConsoleColor>()
            {
                {LogLevel.Debug, ConsoleColor.Gray},
                {LogLevel.Info, ConsoleColor.Green},
                {LogLevel.Error, ConsoleColor.Red},
            }, 1000, new UtcDatetimeProvider(), (m, l, e, s, d) =>
            {
                if (m == null)
                {
                    m = "";
                }

                if (e != null)
                {
                    m += $" {e.ToString()}";
                }

                return $"{d} [{l}] {m}";
            });
    }
}