using Microsoft.Extensions.DependencyInjection;
using RentalCars.Domain.Repositories;
using RentalCars.Infrastructure.Repositories.Relational;

namespace RentalCars.CrossCutting
{
    public static class RepositoryServiceColletionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICarRespository, CarRespository>();

            return services;
        }

        public static IServiceCollection AddRepositoriesSingletonDatabase(this IServiceCollection services)
        {
            services.AddScoped<ICarRespository, Infrastructure.Data.Singleton.CarRespository>();

            return services;
        }
    }
}
