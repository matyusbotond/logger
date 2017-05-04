using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.StreamLogger
{
    /// <summary>
    /// Provide a StreamLogger
    /// </summary>
    public class StreamLoggerProvider : ILoggerProvider
    {
        private readonly Stream _stream;
        private readonly StreamLoggerOptions _options;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream">Log into this stream</param>
        /// <param name="options"></param>
        public StreamLoggerProvider(Stream stream, StreamLoggerOptions options)
        {
            _stream = stream;
            _options = options;
        }

        public ILogger<TSource> CreateLogger<TSource>()
        {
            return new StreamLogger<TSource>(_stream, _options);
        }
    }
}
