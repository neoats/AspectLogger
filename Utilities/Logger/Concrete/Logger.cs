using Serilog;
using Serilog.Events;

namespace Utilities.Logger.Concrete;

public class Logger : ILogger
{
    static readonly ILogger _logger;

    static Logger()
    {
        _logger = new LoggerConfiguration()
            .WriteTo.File(@"C:\Logs\log.txt")
            .CreateLogger();
    }

    public void Write(LogEvent logEvent)
    {
        throw new NotImplementedException();
    }

    public void LogWithDays(string title)
    {
        var now = DateTime.Now;
        var logMessage = $"{now:d} {now:t} \n {title}\n";

        // Log kaydı yapma
        _logger.Information(logMessage);

        // Diğer işlemler...
    }


    public ILogger GetLoggerInstance()
    {
        return _logger;
    }
}

public static class LoggerExtensions
{
    public static void LogWithDays(this ILogger logger, string title)
    {
        var now = DateTime.Now;
        var logMessage = $"{now:d} {now:t} \n {title}";

        // Log kaydı yapma
        logger.Information(logMessage);

        // Diğer işlemler...
    }
}