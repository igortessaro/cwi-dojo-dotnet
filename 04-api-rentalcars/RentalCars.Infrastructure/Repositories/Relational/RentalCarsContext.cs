using Microsoft.EntityFrameworkCore;
using RentalCars.Domain.Entities;
using System.Diagnostics;

namespace RentalCars.Infrastructure.Repositories.Relational
{
    public sealed class RentalCarsContext: DbContext
    {
        public RentalCarsContext()
        {
        }

        public RentalCarsContext(DbContextOptions<RentalCarsContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.CarConfiguration());
        }
    }
}
