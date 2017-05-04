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
    /// <summary>
    /// Options for FileLogger
    /// </summary>
    public class FileLoggerOptions : StreamLoggerOptions
    {
        public int RotatetSize { get; }

        public string FileName { get; }
        public string FileExtension { get; }
        public string FileLocation { get; }

        /// <summary>
        /// ctor of options
        /// </summary>
        /// <param name="rotatetSize">Log file will be achieved if bigger than this (byte)</param>
        /// <param name="fileName">Log file's name</param>
        /// <param name="fileExtension">Log file's extension</param>
        /// <param name="fileLocation">Log file's directory</param>
        /// <param name="dateTimeProvider">Provide actual date for timestamp of logs</param>
        /// <param name="logFormatter">Provide a formatter for logs</param>
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

        /// <summary>
        /// rotatetSize: 5kb
        /// fileName: log
        /// fileExtension: txt
        /// fileLocation: ./
        /// dateTimeProvider: <see cref="UtcDatetimeProvider"/>
        /// logFormatter: <see cref="SimpleLogFormatter"/>
        /// </summary>
        public new static FileLoggerOptions DeafultOptions { get; } = new FileLoggerOptions(
            5*1024,
            "log",
            "txt",
            "",
            new UtcDatetimeProvider(), new SimpleLogFormatter());
    }
}
