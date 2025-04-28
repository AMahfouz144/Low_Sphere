using Common.Logger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Common.Logger.Core;
using Serilog;
using Common.Common;


namespace Common.Core
{
    public static class DI
    {
        //RegisterQRManager
        public static void RegisterCommon(this IServiceCollection services)
        {
            services.UseCustomLogger();

            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<ICurrentRequest, CurrentRequest>();

            services.AddScoped<IGeneratorService, GeneratorService>();
            services.AddScoped<IHashingService, HashingService>();
        }

        public static IApplicationBuilder UseCustomErrorHandling(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<CustomErrorHandling>();
            return builder;
        }

        public static void UseCustomLogger(this IServiceCollection services)
        {
            services.AddScoped<IVLogger, VLogger>();
            //services.AddApplicationInsightsTelemetryWorkerService();
        }

        public static IHostBuilder ConfigureCustomLogger(this IHostBuilder builder, string appInsightConnectionString)
        {
            return builder.UseSerilog((context, services, configuration) => configuration
                   .ReadFrom.Configuration(context.Configuration)
                   .ReadFrom.Services(services)
                   .Enrich.FromLogContext()
                   .WriteTo.Console());
        }

        public static IApplicationBuilder UseCustomLoggerRequestLogging(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseSerilogRequestLogging();
        }

        //public static IApplicationBuilder UseCustomLoggerRequestLogging(this IApplicationBuilder applicationBuilder, Action<RequestLoggingOptions> action)
        //{
        //    return applicationBuilder.UseSerilogRequestLogging(action);
        //}
    }
}