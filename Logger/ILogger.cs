using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public interface ILogger : IDisposable
    {
        void Log(LogLevel logLevel, Exception exception, string message);
    }
}
