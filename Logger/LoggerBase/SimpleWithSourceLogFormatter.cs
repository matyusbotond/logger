using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.LoggerBase
{
    public class SimpleWithSourceLogFormatter : ILogFormatter
    {
        public virtual string Format(Log log)
        {
            var composedMessage = log.Message;

            if (composedMessage == null)
            {
                composedMessage = "";
            }

            if (log.Exception != null)
            {
                composedMessage += $" {log.Exception}";
            }

            return $"{log.Timestamp} [{log.Level}] ({log.Source}) {composedMessage}";
        }
    }
}
