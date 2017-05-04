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
    public class StreamLoggerOptions : ThreadSafeLoggerOptions
    {
        public StreamLoggerOptions(
            IDateTimeProvider dateTimeProvider, 
            ILogFormatter logFormatter) : base(dateTimeProvider, logFormatter)
        {
            
        }

        public static StreamLoggerOptions DeafultOptions { get; } = new StreamLoggerOptions(new UtcDatetimeProvider(), new SimpleLogFormatter());
    }
}
