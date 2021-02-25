using Microsoft.EntityFrameworkCore;
using RentACar.Entities.Concrete;

namespace RentACar.DataAccess.Concrete.EntityFramework
{
    public class RentACarContext:DbContext
    {
        public RentACarContext(DbContextOptions<RentACarContext> options):base(options)
        {
            //Another constructor for use connection string in web api
        }

        public RentACarContext()
        {
            //A Default constructor have to created because of web api
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CarImage> CarImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-2QF0S4K; Initial Catalog = RentACarDb; Integrated Security = True;");
        }
    }
}
