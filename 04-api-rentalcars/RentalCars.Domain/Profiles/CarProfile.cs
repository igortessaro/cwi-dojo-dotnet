using AutoMapper;
using RentalCars.Domain.Commands;
using RentalCars.Domain.Entities;
using RentalCars.Domain.Queries;

namespace RentalCars.Domain.Profiles
{
    public sealed class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarSummary>()
                .ForMember(x => x.Brand, source => source.MapFrom(y => y.Brand))
                .ForMember(x => x.ManufactureYear, source => source.MapFrom(y => y.ManufactureYear))
                .ForMember(x => x.Type, source => source.MapFrom(y => y.Type))
                .ForMember(x => x.Color, source => source.MapFrom(y => y.Color))
                .ForMember(x => x.Plate, source => source.MapFrom(y => y.Plate))
                .ForMember(x => x.ModelYear, source => source.MapFrom(y => y.ModelYear));
            CreateMap<CreateCar, Car>()
                .ForMember(x => x.Brand, source => source.MapFrom(y => y.Brand))
                .ForMember(x => x.ManufactureYear, source => source.MapFrom(y => y.ManufactureYear))
                .ForMember(x => x.Type, source => source.MapFrom(y => y.Type))
                .ForMember(x => x.Color, source => source.MapFrom(y => y.Color))
                .ForMember(x => x.Plate, source => source.MapFrom(y => y.Plate))
                .ForMember(x => x.ModelYear, source => source.MapFrom(y => y.ModelYear));
            CreateMap<UpdateCar, Car>()
                .ForMember(x => x.Id, source => source.MapFrom(y => y.Id))
                .ForMember(x => x.Brand, source => source.MapFrom(y => y.Brand))
                .ForMember(x => x.ManufactureYear, source => source.MapFrom(y => y.ManufactureYear))
                .ForMember(x => x.Type, source => source.MapFrom(y => y.Type))
                .ForMember(x => x.Color, source => source.MapFrom(y => y.Color))
                .ForMember(x => x.Plate, source => source.MapFrom(y => y.Plate))
                .ForMember(x => x.ModelYear, source => source.MapFrom(y => y.ModelYear));
        }
    }
}
