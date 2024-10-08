using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace TempLaboClini.Infrastructure.Logging
{
    public static class LoggingConfiguration
    {
        public static void ConfigureLogging(this ILoggingBuilder loggingBuilder, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog();
        }
       public static void ConfigureLogging(this IHostBuilder hostBuilder)
       {
       }
    }
}
