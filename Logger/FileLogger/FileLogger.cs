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

        public FileLogger(FileLoggerOptions options) : base(options)
        {
            _options = options;
        }

        protected override void LogImpl(Log log)
        {
            if (IsArchivable())
            {
                ArchiveLogs();
            }

            WriteToStream(_options.LogFormatter.Format(log)).Dispose();
        }

        protected virtual bool IsArchivable()
        {
            var filePath = ComposeFilePath(ComposeOriginalFileName());

            if (!File.Exists(filePath))
            {
                return false;
            }

            return new FileInfo(filePath).Length >= _options.RotatetSize;
        }

        protected virtual void ArchiveLogs()
        {
            File.Move(ComposeFilePath(ComposeOriginalFileName()), ComposeFilePath(ComposeNextArchivedFileName()));
        }

        protected override StreamWriter GetStreamWriter()
        {
            return File.AppendText(ComposeFilePath(ComposeOriginalFileName()));
        }

        protected string ComposeFilePath(string fileName)
        {
            return Path.Combine(_options.FileLocation, fileName);
        }

        protected virtual string ComposeOriginalFileName()
        {
            return $"{_options.FileName}.{_options.FileExtension}";
        }
        protected virtual string ComposeNextArchivedFileName()
        {
            var originalFile = new FileInfo(ComposeFilePath(ComposeOriginalFileName()));

            var logFiles = originalFile?.Directory?.GetFiles($"{_options.FileName}.*.{_options.FileExtension}");

            int nextNumber = 1;

            if (logFiles != null && logFiles.Any())
            {
                nextNumber = 1 + logFiles.Select(f =>
                    {
                        int number;

                        var parts = f.Name.Split('.');

                        if (int.TryParse(parts[parts.Length-2], out number))
                        {
                            return number;
                        }

                        return 0;
                    })
                    .Max();
            }

            return $"{_options.FileName}.{nextNumber}.{_options.FileExtension}";
        }
    }
}
