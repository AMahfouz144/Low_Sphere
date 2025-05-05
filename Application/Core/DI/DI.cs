
using Application.Common.MyFramwork;
using Application.Usecases.Account.Commands;
using Application.Usecases.Users.Commands;
using Application.Usecases.Users.Queries;
using Application.Usecases.Users.Queries.GetAll;
using Application.Usecases.Users.Queries.GetById;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DI
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services, ApplicationConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddScoped<IRegisterCommand, RegisterCommand>();
            services.AddScoped<ILoginUserCommand, LoginUserCommand>();
            services.AddScoped<ISignUpCommand, SignUpCommand>();
            services.AddScoped<IAddUserCommand,AddUserCommand>();
            services.AddScoped<IUpdateUserCommand,UpdateUserCommand>();
            services.AddScoped<IGetUsersQuery, GetUsersQuery>();
            services.AddScoped<IGetUserByIdQuery,GetUserByIdQuery>();
            services.AddScoped<IHashingService, HashingService>();
            return services;
        }
    }
}
