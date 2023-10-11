namespace OwnComplex.EF8
{
    class Logger :  Domain.Service.ILogger
    {
        public void LogInformation(string message)
        {
            Console.WriteLine(message);
        }
    }
}
