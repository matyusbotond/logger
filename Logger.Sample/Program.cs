using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Logger.Extensions;

namespace Logger.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            //LoggerFactory.Instance.AddConsole();
            LoggerFactory.Instance.AddFile();

            var memoryStream = new MemoryStream();
            LoggerFactory.Instance.AddStream(memoryStream);

            var streamLogs = Encoding.UTF8.GetString(memoryStream.ToArray());

            Console.WriteLine(streamLogs);

            var tasks = new List<Task>();
            var loggers = new List<ILogger>();

            for (int i = 0; i < 5; i++)
            {
                var i1 = i;
                tasks.Add(Task.Run(async () =>
                {
                    ILogger logger = LoggerFactory.Instance.CreateLogger<Program>();


                    loggers.Add(logger);

                    for (int j = 0; j < 10; j++)
                    {
                        await Task.Delay(100);

                        await logger.LogInfoAsync($"{i1}. logger: asdasd");
                        await logger.LogDebugAsync($"{i1}. logger: asdasd");
                        await logger.LogErrorAsync($"{i1}. logger: asdasd");
                        await logger.LogErrorAsync(new Exception(), $"{i1}. logger: asdasd");
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
