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
            LoggerFactory.Instance.AddConsole();
            LoggerFactory.Instance.AddFile();

            var memoryStream = new MemoryStream();

            LoggerFactory.Instance.AddStream(memoryStream);

            var logger = LoggerFactory.Instance.CreateLogger<Program>();

            logger.LogInfo("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            logger.LogDebug("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            logger.LogError("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            logger.LogError(new Exception("Lorem ipsum dolor sit amet, consectetur adipiscing elit."));
            logger.LogError(new Exception("Lorem ipsum dolor sit amet, consectetur adipiscing elit."), "Lorem ipsum dolor sit amet, consectetur adipiscing elit.");

            SampleAsync(logger).Wait();
        }

        private static async Task SampleAsync(ILogger<Program> logger)
        {
            await logger.LogInfoAsync("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            await logger.LogDebugAsync("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            await logger.LogErrorAsync("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            await logger.LogErrorAsync(new Exception("Lorem ipsum dolor sit amet, consectetur adipiscing elit."));
            await logger.LogErrorAsync(new Exception("Lorem ipsum dolor sit amet, consectetur adipiscing elit."), "Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
        }
    }
}
