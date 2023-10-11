using Microsoft.Extensions.Logging;

namespace OwnComplex.EF6SimpleId
{
    class Logger :  Domain.Service.ILogger
    {
        public void LogInformation(string message)
        {
            Console.WriteLine(message);
        }
    }
}
