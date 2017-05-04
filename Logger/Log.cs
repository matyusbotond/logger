using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Log
    {
        public Log(DateTimeOffset timestamp, Exception exception, string message, LogLevel level, Type source)
        {
            Timestamp = timestamp;
            Exception = exception;
            Message = message;
            Level = level;
            Source = source;
        }

        public Type Source { get; }

        public DateTimeOffset Timestamp { get;  }

        public Exception Exception { get; }

        public string Message { get; }

        public LogLevel Level { get;  }
    }
}
