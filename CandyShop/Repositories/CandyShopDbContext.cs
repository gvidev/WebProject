using CandyShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace CandyShop.Repositories
{
    public class CandyShop_DbContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        public CandyShop_DbContext()
        {
            Users = this.Set<User>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GEORGI_VIDEV;Database=CandyShopDB;User Id=gvidev;Password=adminpass;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Username = "g",
                    Password = "g",
                    FirstName = "Georgi",
                    LastName = "Videv"
                }
                );
        }
    }
}
