using AutoMapper;
using RentalCars.Domain.Commands;
using RentalCars.Domain.Entities;
using RentalCars.Domain.Queries;
using RentalCars.Domain.Repositories;

namespace RentalCars.Domain.Services
{
    public sealed class CarService : ICarService
    {
        private readonly ICarRespository _carRespository;
        private readonly IMapper _mapper;

        public CarService(ICarRespository carRespository, IMapper mapper)
        {
            this._carRespository = carRespository;
            this._mapper = mapper;
        }

        public Car Create(CreateCar car)
        {
            Car entity = this._mapper.Map<Car>(car);
            Car createdCar = this._carRespository.Create(entity);

            return createdCar;
        }

        public Car Update(UpdateCar car)
        {
            Car entity = this._mapper.Map<Car>(car);
            Car updatedCar = this._carRespository.Update(entity);

            return updatedCar;
        }

        public void Delete(DeleteCar car)
        {
            this._carRespository.Delete(car.Id);
        }

        public IReadOnlyList<CarSummary> GetAll()
        {
            var result = this._carRespository.GetAll();

            return result;
        }

        public IReadOnlyList<CarSummary> GetByBrand(string brand)
        {
            var result = this._carRespository.GetByBrand(brand);

            return result;
        }

        public CarSummary Get(int id)
        {
            var result = this._carRespository.Get(id);

            return result;
        }
    }
}
