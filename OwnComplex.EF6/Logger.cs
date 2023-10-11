using Microsoft.Extensions.Logging;

namespace OwnComplex.EF6
{
    class Logger :  Domain.Service.ILogger
    {
        public void LogInformation(string message)
        {
            Console.WriteLine(message);
        }
    }
}
