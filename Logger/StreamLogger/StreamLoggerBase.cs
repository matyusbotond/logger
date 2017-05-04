using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Logger.ThreadSafeLoggerBase;

namespace Logger.StreamLogger
{
    public abstract class StreamLoggerBase<TSource> : ThreadSafeLoggerBase<TSource>
    {
        private readonly StreamLoggerOptions _options;

        protected StreamLoggerBase(StreamLoggerOptions options) : base(options)
        {
            _options = options;
        }

        protected override void LogImpl(Log log)
        {
            WriteToStream(_options.LogFormatter.Format(log));
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
