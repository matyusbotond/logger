using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerFactory.Instance.AddConsole();
            LoggerFactory.Instance.AddFile();

            var memoryStream = new MemoryStream();
            LoggerFactory.Instance.AddStream(memoryStream);

            var streamLogs = Encoding.UTF8.GetString(memoryStream.ToArray());

            Console.WriteLine(streamLogs);

            var tasks = new List<Task>();
            var loggers = new List<ILogger>();

            for (int i = 0; i < 50; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    ILogger logger;

                    switch (i%3)
                    {
                        case 0:
                            logger = LoggerFactory.Instance.CreateLogger<Program>();
                            break;
                        case 1:
                            logger = LoggerFactory.Instance.CreateLogger<string>();
                            break;
                        case 2:
                            logger = LoggerFactory.Instance.CreateLogger<int>();
                            break;
                        default:
                            logger = LoggerFactory.Instance.CreateLogger<object>();
                            break;
                    }

                    loggers.Add(logger);

                    for (int j = 0; j < 10; j++)
                    {
                        logger.LogDebug("asdasd");
                        logger.LogInfo("asdasd");
                        logger.LogError(new Exception("asdasd"), "asd");
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

            foreach (var logger in loggers)
            {
                logger.Dispose();
            }
        }
    }
}
