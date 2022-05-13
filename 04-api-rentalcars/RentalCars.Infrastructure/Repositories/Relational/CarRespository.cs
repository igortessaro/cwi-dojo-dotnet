using AutoMapper;
using RentalCars.Domain.Entities;
using RentalCars.Domain.Queries;
using RentalCars.Domain.Repositories;
using RentalCars.Infrastructure.Repositories.Relational.Core;

namespace RentalCars.Infrastructure.Repositories.Relational
{
    public sealed class CarRespository : BaseRepository<Car>, ICarRespository
    {
        public CarRespository(RentalCarsContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public Car Create(Car car)
        {
            this.InsertBase(car);
            this.Commit();

            return car;
        }

        public void Delete(int id)
        {
            var entity = this.QueryTracking().First(x => x.Id == id);

            this.DeleteBase(entity);
            this.Commit();
        }

        public CarSummary? Get(int id)
        {
            return this.Query<CarSummary>(x => x.Id == id).FirstOrDefault();
        }

        public IReadOnlyList<CarSummary> GetAll()
        {
            return this.Query<CarSummary>().ToList();
        }

        public IReadOnlyList<CarSummary> GetByBrand(string brand)
        {
            return this.Query<CarSummary>(x => x.Brand == brand).ToList();
        }

        public Car Update(Car car)
        {
            this.UpdateBase(car);
            this.Commit();

            return car;
        }
    }
}
