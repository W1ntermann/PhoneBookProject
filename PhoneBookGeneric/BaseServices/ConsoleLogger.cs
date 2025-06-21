namespace PhoneBookGeneric.BaseServices;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Action :" + message);
    }
}