using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.LoggerBase;
using Logger.Providers;
using Logger.StreamLogger;

namespace Logger.FileLogger
{
    public class FileLoggerOptions : StreamLoggerOptions
    {
        public int RotatetSize { get; }

        public string FileName { get; }
        public string FileExtension { get; }
        public string FileLocation { get; }

        public FileLoggerOptions(
            int rotatetSize,
            string fileName,
            string fileExtension,
            string fileLocation,
            IDateTimeProvider dateTimeProvider, 
            ILogFormatter logFormatter) : base(dateTimeProvider, logFormatter)
        {
            //TODO paraméterek vizsgálata
            RotatetSize = rotatetSize;
            FileName = fileName;
            FileExtension = fileExtension;
            FileLocation = fileLocation;
        }

        public new static FileLoggerOptions DeafultOptions { get; } = new FileLoggerOptions(
            5*1024,
            "log",
            "txt",
            "",
            new UtcDatetimeProvider(), new SimpleLogFormatter());
    }
}
