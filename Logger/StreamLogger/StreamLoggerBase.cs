using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Logger.StreamLogger
{
    public abstract class StreamLoggerBase<TSource> : ThreadSafeLoggerBase<TSource>
    {
        private readonly StreamLoggerOptions _options;

        protected StreamLoggerBase(StreamLoggerOptions options) : base(options)
        {
            _options = options;
        }

        protected override void LogImpl(LogLevel logLevel, Exception exception, string message, DateTimeOffset dateTimeOffset)
        {
            WriteToStream(_options.LogMessageComposer(message, logLevel, exception, dateTimeOffset, Source));
        }

        protected abstract StreamWriter GetStreamWriter();

        protected virtual StreamWriter WriteToStream(string data)
        {
            var streamWriter = GetStreamWriter();

            streamWriter.WriteLine(data);

            streamWriter.Flush();

            return streamWriter;
        }
    }
}
