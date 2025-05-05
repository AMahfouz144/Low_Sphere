
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Core
{
    public static class DI
    {
        public static void RegisterInfrastructre(this IServiceCollection services, InfraStructureConfiguration config)
        {
            //services.AddSingleton(config);

            //services.AddScoped<IFileManagerService, FileManagerService>();
        }
    }
}