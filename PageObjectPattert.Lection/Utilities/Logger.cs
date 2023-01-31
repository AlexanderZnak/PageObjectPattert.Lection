using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;

namespace PageObjectPattert.Lection.Utilities;

public sealed class Logger
{
    private static readonly Lazy<Logger> LazyInstance = new Lazy<Logger>(() => new Logger());

    private readonly ILogger _log = LogManager.GetLogger(Thread.CurrentThread.ManagedThreadId.ToString());

    private Logger()
    {
        try
        {
            LogManager.LoadConfiguration("NLog.config");
        }
        catch (FileNotFoundException)
        {
            LogManager.Configuration = GetConfiguration();
        }
    }

    private LoggingConfiguration GetConfiguration()
    {
        string str = "${date:format=yyyy-MM-dd HH\\:mm\\:ss} ${level:uppercase=true} - ${message}";
        LoggingConfiguration configuration = new LoggingConfiguration();

        // for console
        LogLevel info = LogLevel.Info;
        LogLevel fatal1 = LogLevel.Fatal;
        ConsoleTarget consoleTarget = new ConsoleTarget("logconsole");
        consoleTarget.Layout = (Layout)str;
        configuration.AddRule(info, fatal1, (Target)consoleTarget);

        // for file
        LogLevel debug = LogLevel.Debug;
        LogLevel fatal2 = LogLevel.Fatal;
        FileTarget fileTarget = new FileTarget("logfile");
        fileTarget.DeleteOldFileOnStartup = true;
        fileTarget.FileName = (Layout)"../../../Log/log.log";
        fileTarget.Layout = (Layout)str;
        configuration.AddRule(debug, fatal2, (Target)fileTarget);
        return configuration;
    }

    public static Logger Instance => LazyInstance.Value;

    public void Debug(string message) => _log.Debug(message);

    public void Info(string message) => _log.Info(message);

    public void Warn(string message) => _log.Warn(message);

    public void Error(string message) => _log.Error(message);

    public void Fatal(string message) => _log.Fatal(message);
}