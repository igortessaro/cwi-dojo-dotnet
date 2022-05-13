using RentalCars.Domain.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DomainServiceColletionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();

            return services;
        }
    }
}
