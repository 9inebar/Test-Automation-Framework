using Serilog;
namespace Epam.TestAutomation.Core.Utils;

public class Logger
{
    private static ILogger logger = null;

    public static void Info(string message)
    {
        logger.Information(message);
    }

    public static void InitLogger(string loggerName, string pathToFolder)
    {
        Directory.CreateDirectory(pathToFolder);
        logger = new LoggerConfiguration().WriteTo.File
            (Path.Combine(pathToFolder, loggerName + ".txt"), rollingInterval: RollingInterval.Day).CreateLogger();
    }
}