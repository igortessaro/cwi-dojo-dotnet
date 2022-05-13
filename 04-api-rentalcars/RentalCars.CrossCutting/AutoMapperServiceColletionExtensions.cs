using Microsoft.Extensions.DependencyInjection;
using RentalCars.Domain.Profiles;

namespace RentalCars.CrossCutting
{
    public static class AutoMapperServiceColletionExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile<CarProfile>());

            return services;
        }
    }
}
