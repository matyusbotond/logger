using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.ConsoleLogger
{
    /// <summary>
    /// Provide an ConsoleLogger
    /// </summary>
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        private readonly ConsoleLoggerOptions _options;

        public ConsoleLoggerProvider(ConsoleLoggerOptions options)
        {
            _options = options;
        }

        public ILogger<TSource> CreateLogger<TSource>()
        {
            return new ConsoleLogger<TSource>(_options);
        }
    }
}
