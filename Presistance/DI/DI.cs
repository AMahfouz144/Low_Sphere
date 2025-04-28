using Application.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presistance.Core;
using Presistence.Core;

namespace Presistance
{
    public static class DI
    {
        public static void RegisterPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IDatabaseServiceOptions>(provider => new DatabaseServiceOptions() { ConnectionString = connectionString, Provider = services.BuildServiceProvider() });

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IDatabaseService, DatabaseService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        }
    }
}