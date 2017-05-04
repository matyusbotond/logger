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
    /// <summary>
    /// Base class for stream based logger
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
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

        /// <summary>
        /// Create a streamWriter with the stream
        /// </summary>
        /// <returns></returns>
        protected abstract StreamWriter GetStreamWriter();

        /// <summary>
        /// Write a message into the stream with <see cref="GetStreamWriter"/>
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected virtual StreamWriter WriteToStream(string data)
        {
            var streamWriter = GetStreamWriter();

            streamWriter.WriteLine(data);

            streamWriter.Flush();

            return streamWriter;
        }
    }
}
