using CandyShop.Entities;
using Microsoft.EntityFrameworkCore;
using CandyShop.ViewModels.Account;

namespace CandyShop.Repositories
{
    public class CandyShopDbContext:DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart_Session> Cart_Sessions { get; set; }
        public DbSet<Cart_Products> Cart_Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Products> Order_Products { get; set; }

        public CandyShopDbContext()
        {
            this.Users = this.Set<User>();
            this.Products = this.Set<Product>();
            this.Cart_Products= this.Set<Cart_Products>();
            this.Orders = this.Set<Order>();
            this.Cart_Sessions = this.Set<Cart_Session>();
            this.Order_Products= this.Set<Order_Products>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GEORGI_VIDEV;Database=CandyShopDB;User Id=gvidev;Password=g20022002g20.05;");
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
                    LastName = "Videv",
                    isAdmin=true,
                    CreatedDate= DateTime.Now
                },
                new User()
                {
                    Id = 2,
                    Username = "hrisipisi",
                    Password = "h2002d",
                    Email = "hrisid@gmail.com",
                    FirstName = "Hristina",
                    LastName = "Despinova",
                    isAdmin = true,
                    CreatedDate = DateTime.Now
                }

            );
        }

    }
}
