namespace  TempLaboClini.Infrastructure.Configuration
{
 using System.Collections.Generic;

    public enum LogLevel
   {
     Verbose,
     Debug,
     Information,
     Warning,
     Error,
     Fatal
   }
    public class LoggingConfiguration
    {
        public LogLevel DefaultLogLevel { get; set; }
        public Dictionary<string, LogLevel> LogLevels { get; set; }
    }
}
