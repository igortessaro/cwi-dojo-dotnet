using AutoMapper;
using RentalCars.Domain.Entities;
using RentalCars.Domain.Queries;
using RentalCars.Domain.Repositories;
using System.Linq.Expressions;

namespace RentalCars.Infrastructure.Data.Singleton
{
    public sealed class CarRespository : ICarRespository
    {
        private readonly RentalCarsContext _context;
        private readonly IMapper _mapper;

        public CarRespository(RentalCarsContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public void Commit()
        {

        }

        public Car Create(Car car)
        {
            int maxId = this._context.Cars.Any() ? this._context.Cars.Select(x => x.Id).Max() : 0;
            car.Id = maxId + 1;
            this._context.Cars.Add(car);
            return car;
        }

        public void Delete(int id)
        {
            var carToDelete = this._context.Cars.FirstOrDefault(c => c.Id == id);

            if (carToDelete is null)
            {
                return;
            }

            this.DeleteBase(carToDelete);
        }

        public void DeleteBase(Car entity)
        {
            this._context.Cars.Remove(entity);
        }

        public CarSummary? Get(int id)
        {
            var car = this._context.Cars.FirstOrDefault(c => c.Id == id);

            if (car is null)
            {
                return null;
            }

            CarSummary result = this._mapper.Map<CarSummary>(car);

            return result;
        }

        public IReadOnlyList<CarSummary> GetAll()
        {
            if (!this._context.Cars.Any())
            {
                return new List<CarSummary>();
            }

            return this._context.Cars.Select(c => this._mapper.Map<CarSummary>(c)).ToList();
        }

        public IReadOnlyList<CarSummary> GetByBrand(string brand)
        {
            var cars = this._context.Cars.Where(c => brand.Equals(c.Brand)).ToList();

            if (!cars.Any())
            {
                return new List<CarSummary>();
            }

            return cars.Select(c => this._mapper.Map<CarSummary>(c)).ToList();
        }

        public void InsertBase(Car entity)
        {
            if (entity is null)
            {
                return;
            }

            this._context.Cars.Add(entity);
        }

        public IQueryable<Car> Query(int take = 100)
        {
            return this._context.Cars.AsQueryable();
        }

        public IQueryable<TProjetion> Query<TProjetion>(Expression<Func<Car, bool>> predicate) where TProjetion : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<TProjetion> Query<TProjetion>() where TProjetion : class
        {
            throw new NotImplementedException();
        }

        public Car Update(Car car)
        {
            this.UpdateBase(car);

            return car;
        }

        public void UpdateBase(Car entity)
        {
            this.Delete(entity.Id);
            this.InsertBase(entity);
        }
    }
}
