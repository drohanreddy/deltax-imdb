using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeltaX.Core.Infrastructure
{
    public static class Extensions
    {
        public static bool IsNullOrDefault<T>(this T type)
        {
            return (type == null || type.Equals(default(T)));
        }

        public static void LogMethodExecution(this ILogger logger, DateTime started, TimeSpan duration, bool success, string methodName)
        {
            string response = $"{methodName} started at {started.ToString()} and executed for {duration.TotalMilliseconds} and succeded = {success}";
            logger.LogInformation(response);
        }
    }
}
