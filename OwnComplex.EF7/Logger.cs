using Microsoft.Extensions.Logging;

namespace OwnComplex.EF7;

internal class Logger : Domain.Service.ILogger
{
    public void LogInformation(string message)
    {
        Console.WriteLine(message);
    }
}