using Serilog;
using Utilities.Interceptors;
using Utilities.Logger.Concrete;

namespace Utilities.Aspect.Concrete;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class LoggingAspectAttribute : MethodInterceptionBaseAttribute
{
    readonly ILogger _logger;

    public LoggingAspectAttribute()
    {
        _logger = new Logger.Concrete.Logger();
    }

    public void OnBefore(string methodName, object[] arguments)
    {
        var logMessage = GetLogMessage(methodName, arguments);
        _logger.LogWithDays(logMessage);
    }

    string GetLogMessage(string methodName, object[] arguments)
    {
        var parameterNames = arguments.Select((arg, index) => $"[{index}]: {arg}");
        return $"Executed method '{methodName}' with parameters: {string.Join(", ", parameterNames)}";
    }
}