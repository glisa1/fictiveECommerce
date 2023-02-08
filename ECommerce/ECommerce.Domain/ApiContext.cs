using ECommerce.Domain.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Domain
{
    public class ApiContext : DbContext, IApiContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApiContext()
        {
            AddTestData();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "DemoDb");
        }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        private async void AddTestData()
        {
            Random random = new Random();
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FullName = "Full Test Name",
                    Username = "fullTestName",
                    Cart = new List<CartItem>()
                },
                new Customer
                {
                    Id = 2,
                    FullName = "Test Full Name",
                    Username = "testFullName",
                    Cart = new List<CartItem>()
                }
            };

            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Test product 1",
                    Quantity = 10,
                    Price = (decimal)(random.Next(600) * random.NextDouble())
                },
                new Product
                {
                    Id = 2,
                    Name = "Test product 2",
                    Quantity = 10,
                    Price = (decimal)(random.Next(600) * random.NextDouble())
                },
                new Product
                {
                    Id = 3,
                    Name = "Test product 3",
                    Quantity = 10,
                    Price = (decimal)(random.Next(600) * random.NextDouble())
                },
                new Product
                {
                    Id = 4,
                    Name = "Test product 4",
                    Quantity = 10,
                    Price = (decimal)(random.Next(600) * random.NextDouble())
                }
            };

            var orders = new List<Order>();

            Customers.AddRange(customers);
            Products.AddRange(products);
            Orders.AddRange(orders);
            await SaveChangesAsync();
        }
    }
}
