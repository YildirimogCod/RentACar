using Microsoft.EntityFrameworkCore;
using RentCar.Domain.Entities;

namespace RentCar.Persistence.Context
{
    public class RentCarDbContext:DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }

        public DbSet<RentedCar> RentedCars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=RentCarDb;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
