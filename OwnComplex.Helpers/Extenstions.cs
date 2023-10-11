using Microsoft.Extensions.Logging;

namespace OwnComplex.Helpers
{
    public static class Extenstions
    {
  

        public static async Task<T> CallWithMetric<T>(this Func<Task<T>> func, ILogger logger)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var retValue = await func();
            watch.Stop();
            logger.LogDebug($"Function: {func.Method.Name} called in time: {watch.Elapsed:g}");
            return retValue;
        }

        public static async Task CallWithMetric(this Action action, ILogger logger, params object?[]? args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            action.DynamicInvoke();
            watch.Stop();
            logger.LogDebug($"Function: {action.Method.Name} called in time: {watch.Elapsed:g}");
        }
    }
}
