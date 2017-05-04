using Logger.StreamLogger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Logger.FileLogger
{
    public class FileLogger<TSource> : StreamLoggerBase<TSource>
    {
        private readonly FileLoggerOptions _options;

        //TODO átgondolni
        private static int _rotatetNumber = 0;

        public FileLogger(FileLoggerOptions options) : base(options)
        {
            _options = options;
        }

        protected override void LogImpl(LogLevel logLevel, Exception exception, string message, DateTimeOffset dateTimeOffset)
        {
            //TODO set rotate number

            WriteToStream(_options.LogMessageComposer(message, logLevel, exception, dateTimeOffset, Source)).Dispose();
        }

        protected override StreamWriter GetStreamWriter()
        {
            return File.AppendText(Path.Combine(_options.FileLocation, ComposeFileName(_rotatetNumber)));
        }


        protected virtual string ComposeFileName(int roatetNumber)
        {
            return $"{_options.FileName}.{roatetNumber}.{_options.FileExtension}";
        }
    }
}
