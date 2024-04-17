namespace Factory.Implementations;

public interface ILogger
{
    void LogMessage(string message);
}

public class FileLogger : ILogger
{
    public void LogMessage(string message)
    {
        //Log message to a file
        Console.WriteLine("File Logger: " + message);
    }
}

public class ConsoleLogger : ILogger
{
    public void LogMessage(string message)
    {
        //Log message to the console
        Console.WriteLine("Console Logger: " + message);
    }
}

public abstract class LoggerFactory
{
    public abstract ILogger CreateLogger();
}

public class FileLoggerFactory : LoggerFactory
{
    public override ILogger CreateLogger()
    {
        return new FileLogger();
    }
}

public class ConsoleLoggerFactory : LoggerFactory
{
    public override ILogger CreateLogger()
    {
        return new ConsoleLogger();
    }
}