using log4net;

namespace SauceDemoTests.Helpers;

public static class LogHelper
{
    private static readonly ILog Log = LogManager.GetLogger("TestFramework");

    public static void Info(string message)
    {
        Log.Info(message);
    }
    
    public static void Warn(string message)
    {
        Log.Warn(message);
    }

    public static void Error(string message)
    {
        Log.Error(message);
    }

    public static void Debug(string message)
    {
        Log.Debug(message);
    }

    public static void Error(string message, Exception exception)
    {
        Log.Error(message, exception);
    }
}
