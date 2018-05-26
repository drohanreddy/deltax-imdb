using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog.Sinks.File;
namespace DeltaX.Core.Infrastructure
{
    public class LoggerHelper
    {
        public Serilog.LoggerConfiguration GetLoggerConfig()
        {
            return new LoggerConfiguration().
                    WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day);
        }
        public static class ApiLogger
        {
            public static ILogger Write()
            {
                return Log.Logger;
            }
        }
    }
}
