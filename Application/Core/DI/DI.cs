
using Application.Usecases.Account.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DI
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services, ApplicationConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddScoped<IRegisterCommand, RegisterCommand>();
            return services;
        }
    }
}
