namespace Singleton;

public sealed class Logger
{
    private static readonly Lazy<Logger> LazyLogger = new Lazy<Logger>(() => new Logger());

    public static Logger Instance => LazyLogger.Value;

    private Logger()
    {
    }

    public static void LogMessage(string message)
    {
        //Log message here
        Console.WriteLine("Message:" + message);
    }
}