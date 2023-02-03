using CandyShop.Entities;
using Microsoft.EntityFrameworkCore;
using CandyShop.ViewModels.Account;

namespace CandyShop.Repositories
{
    public class CandyShopDbContext:DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public CandyShopDbContext()
        {
            this.Users = this.Set<User>();
            this.Products = this.Set<Product>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GEORGI_VIDEV;Database=CandyShopDb;User Id=gvidev;Password=adminpass;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Username= "gvidev",
                    Password= "pass123",
                    Email= "gvidev@gmail.com",
                    FirstName="Georgi",
                    LastName = "Videv"
                }

            );
        }

    }
}
