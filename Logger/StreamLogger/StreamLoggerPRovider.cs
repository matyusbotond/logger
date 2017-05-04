using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.StreamLogger
{
    public class StreamLoggerProvider : ILoggerProvider
    {
        private readonly Stream _stream;
        private readonly StreamLoggerOptions _options;

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
