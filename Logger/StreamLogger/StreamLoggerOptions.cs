using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Providers;

namespace Logger.StreamLogger
{
    public class StreamLoggerOptions : ThreadSafeLoggerOptions
    {
        public StreamLoggerOptions(
            IDateTimeProvider dateTimeProvider, 
            Func<string, LogLevel, Exception, DateTimeOffset, Type, string> logMessageComposer) : base(dateTimeProvider, logMessageComposer)
        {
            
        }

        public static StreamLoggerOptions DeafultOptions { get; } = new StreamLoggerOptions(new UtcDatetimeProvider(), (m, l, e, d, s) =>
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
