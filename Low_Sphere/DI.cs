using Application;
using Common.Swagger;
using Infrastructure.Core;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Presistance;
using System.Globalization;

namespace API
{
    public static class DI
    {
        public static void Startup(this WebApplicationBuilder builder)
        {
            //Disable Automatic Model State Validation 
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            //Localization
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            builder.Services.AddCors(o => o.AddPolicy("angular2Client", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            }));
            builder.Services.Configure<RequestLocalizationOptions>(opt =>
            {
                var supportlang = new List<CultureInfo>()
                {
                    new CultureInfo("en"),
                    new CultureInfo("ar-EG")
                    {
                        DateTimeFormat =  new DateTimeFormatInfo()
                        {
                            ShortDatePattern = "yyyy/MM/DD",
                            LongDatePattern = "yyyy/MM/DD"
                        }
                    }
                };

                opt.DefaultRequestCulture = new RequestCulture("en");
                opt.SupportedCultures = supportlang;
                opt.SupportedUICultures = supportlang;
            });

            //set Maximum request lenght to avoid multi part size error 
            builder.Services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            builder.Services.AddHttpContextAccessor();
            var publishDate = $"{DateTime.UtcNow.ToString()} UTC Time.";
            builder.Services.UseCustomSwagger("Low_Sphere APIs", builder.Environment.EnvironmentName, publishDate, false);
            builder.RegisterLayers();
            builder.Services.AddMemoryCache();
        }
        public static void RegisterLayers(this WebApplicationBuilder builder)
        {
            //=======Register Common===================================
            //builder.Services.RegisterCommon();
            //var appInsight = builder.Configuration.GetSection("ApplicationInsights");
            //builder.Host.ConfigureCustomLogger(appInsight.GetValue<string>("ConnectionString"));

            //========================Register Application =================
            var applicationConfig = builder.Configuration.GetSection("ApplicationConfiguration").Get<ApplicationConfiguration>();
            builder.Services.RegisterApplication(applicationConfig);

            //========================Register Persistence and Infra =================
            builder.Services.RegisterInfrastructre(builder.Configuration.GetSection("InfraStructure").Get<InfraStructureConfiguration>());
            builder.Services.RegisterPersistence(builder.Configuration["Database"].ToString());
        }
    }
}
