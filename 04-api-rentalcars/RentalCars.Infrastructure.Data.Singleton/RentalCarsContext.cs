using RentalCars.Domain.Entities;

namespace RentalCars.Infrastructure.Data.Singleton
{
    public sealed class RentalCarsContext
    {
        public IList<Car> Cars { get; set; }

        public RentalCarsContext()
        {
            this.Cars = new List<Car>();
        }
    }
}
