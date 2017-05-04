using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.StreamLogger
{
    /// <summary>
    /// Log in stream
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public class StreamLogger<TSource> : StreamLoggerBase<TSource>
    {
        private readonly Stream _stream;

        public StreamLogger(Stream stream, StreamLoggerOptions options) : base(options)
        {
            _stream = stream;
        }

        protected override StreamWriter GetStreamWriter()
        {
            return new StreamWriter(_stream);
        }

        public override void Dispose()
        {
            base.Dispose();

            _stream.Dispose();
        }
    }
}
