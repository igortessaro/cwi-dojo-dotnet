using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalCars.Infrastructure.Repositories.Relational;

namespace RentalCars.CrossCutting
{
    public static class DatabaseServiceColletionExtensions
    {
        public static IServiceCollection AddSqlServerDatabase(this IServiceCollection services, IConfiguration configuration, bool useInMemoryDataBase = false)
        {
            string connectionString = configuration.GetConnectionString("RentalCarsDb");

            if (string.IsNullOrEmpty(connectionString) && !useInMemoryDataBase)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            services.AddDbContext<RentalCarsContext>(options =>
            {
                if (useInMemoryDataBase)
                {
                    options.UseInMemoryDatabase("dbInMemory");
                }
                else
                {
                    options.UseSqlServer(connectionString);
                }
            });

            return services;
        }

        public static IServiceCollection AddSingletonDatabase(this IServiceCollection services)
        {
            services.AddSingleton<Infrastructure.Data.Singleton.RentalCarsContext>();

            return services;
        }
    }
}
