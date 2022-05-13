using RentalCars.Domain.Commands;
using RentalCars.Domain.Entities;
using RentalCars.Domain.Queries;

namespace RentalCars.Domain.Services
{
    public interface ICarService
    {
        Car Create(CreateCar car);
        void Delete(DeleteCar car);
        CarSummary Get(int id);
        IReadOnlyList<CarSummary> GetAll();
        IReadOnlyList<CarSummary> GetByBrand(string brand);
        Car Update(UpdateCar car);
    }
}