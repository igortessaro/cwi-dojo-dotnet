using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalCars.Domain.Entities;

namespace RentalCars.Infrastructure.Repositories.Relational.Configurations
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Car", "RentalCars");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(e => e.Type).HasColumnName("Type");
            builder.Property(e => e.ModelYear).HasColumnName("ModelYear");
            builder.Property(e => e.ManufactureYear).HasColumnName("ManufactureYear");
            builder.Property(e => e.Brand).HasColumnName("Brand");
            builder.Property(e => e.Color).HasColumnName("Color");
            builder.Property(e => e.Plate).HasColumnName("Plate");
        }
    }
}
