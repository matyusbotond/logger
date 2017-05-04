using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.LoggerBase;
using Logger.Providers;
using Logger.ThreadSafeLoggerBase;

namespace Logger.StreamLogger
{
    /// <summary>
    /// Options for StreamLogger
    /// </summary>
    public class StreamLoggerOptions : ThreadSafeLoggerOptions
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="dateTimeProvider">Provide actual date for timestamp of logs</param>
        /// <param name="logFormatter">Provide a formatter for logs</param>
        public StreamLoggerOptions(
            IDateTimeProvider dateTimeProvider, 
            ILogFormatter logFormatter) : base(dateTimeProvider, logFormatter)
        {
            
        }

        /// <summary>
        /// dateTimeProvider: <see cref="UtcDatetimeProvider"/>
        /// logFormatter: <see cref="SimpleLogFormatter"/>
        /// </summary>
        public static StreamLoggerOptions DeafultOptions { get; } = new StreamLoggerOptions(new UtcDatetimeProvider(), new SimpleLogFormatter());
    }
}
