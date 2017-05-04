using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    /// <summary>
    /// Provide logging interface and utility functions
    /// </summary>
    public interface ILogger : IDisposable
    {
        /// <summary>
        /// Log some message or exception
        /// </summary>
        /// <param name="logLevel">Log message leve</param>
        /// <param name="exception">Exception for log message</param>
        /// <param name="message">Custom message of log</param>
        void Log(LogLevel logLevel, Exception exception, string message);
    }
}
