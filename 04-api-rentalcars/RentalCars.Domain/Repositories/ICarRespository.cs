using RentalCars.Domain.Entities;
using RentalCars.Domain.Queries;
using RentalCars.Domain.Repositories.Core;

namespace RentalCars.Domain.Repositories
{
    public interface ICarRespository: IBaseRepository<Car>
    {
        Car Create(Car car);
        void Delete(int id);
        CarSummary? Get(int id);
        IReadOnlyList<CarSummary> GetAll();
        IReadOnlyList<CarSummary> GetByBrand(string brand);
        Car Update(Car car);
    }
}
