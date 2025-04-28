using Serilog;
using Common.Logger;

namespace Common.Logger.Core
{
    public class VLogger : IVLogger
    {
        private readonly ILogger logger;
        public VLogger(ILogger logger)
        {
            this.logger = logger;
        }

        //public static void CreateBootstrapLogger()
        //{
        //    Log.Logger = new LoggerConfiguration()
        //                          .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        //                          .Enrich.FromLogContext()
        //                          .WriteTo.Console()
        //                          .WriteTo.ApplicationInsights(TelemetryConfiguration.Active, TelemetryConverter.Traces)
        //                          .CreateBootstrapLogger();
        //}

        public void Audit(string action, string userId, string description, string rid)
        {
            logger.Verbose("action: {0}, userId: {1}, description: {2}, rid: {3}", action, userId, description, rid);
        }

        public void Audit(string action, string userId, string description)
        {
            logger.Verbose("action: {0}, userId: {1}, description: {2}", action, userId, description);
        }

        public void Critical(string message, string rid, string description = null)
        {
            logger.Fatal("message: {0}, description: {1}, rid: {2}", message, description, rid);
        }

        //public void Error(QError error)
        //{
        //    logger.Error("error details: {@error}", error);
        //}

        public void Error(string message, string rid, string description = null)
        {
            logger.Error("message: {0}, description: {1}, rid: {2}", message, description, rid);
        }

        public bool Error(string message, string clientMessage, string stacktrace, string description, int type)
        {
            logger.Warning("message: {0}, clientMessage: {1}, stacktrace: {2}, description: {3}, type: {4}", message, clientMessage, stacktrace, description, type);
            return true;
        }

        public bool Error(string message, string source)
        {
            logger.Error("message: {0}, source: {1}", message, source);
            return true;
        }

        public bool Info(string message, string source)
        {
            logger.Information("message: {0}, source: {1}", message, source);
            return true;
        }

        public bool Warning(string message, string source)
        {
            logger.Warning("message: {0}, source: {1}", message, source);
            return true;
        }

        public void Watch(string message)
        {
            logger.Debug("message: {0}", message);
        }

        public void Watch(string message, string rid)
        {
            logger.Debug("message: {0}, rid: {1}", message, rid);
        }
    }
}
