using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.FileLogger
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly FileLoggerOptions _options;

        public FileLoggerProvider(FileLoggerOptions options)
        {
            _options = options;
        }

        public ILogger<TSource> CreateLogger<TSource>()
        {
            return new FileLogger<TSource>(_options);
        }
    }
}
