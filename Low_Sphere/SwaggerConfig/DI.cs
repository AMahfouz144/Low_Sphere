using Microsoft.OpenApi.Models;

namespace Common.Swagger
{
    public static class DI
    {
        public static void UseCustomSwagger(this IServiceCollection services,string serivceName, string environmentName, string description, bool allowCustomHeaderAttribute = true)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = $"{serivceName} ({environmentName}) ", Description = $"{description}", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id= "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });

                if (allowCustomHeaderAttribute)
                    opt.OperationFilter<CustomHeaderSwaggerAttribute>();

                opt.OperationFilter<AddAuthHeaderOperationFilter>();
                opt.SchemaFilter<AddAuthHeaderSchemaFilter>();
            });
        }
    }
}