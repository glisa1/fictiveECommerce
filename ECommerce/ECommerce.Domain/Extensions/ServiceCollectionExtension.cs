using ECommerce.Domain.Models.Domain;
using ECommerce.Domain.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Domain.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureDomain(this IServiceCollection services)
        {
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            AddTestData();
        }

        private static void AddTestData()
        {
            Random random = new Random();
            using var context = new ApiContext();
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FullName = "Full Test Name",
                    Username = "fullTestName",
                    Cart = new List<Product>()
                },
                new Customer
                {
                    Id = 2,
                    FullName = "Test Full Name",
                    Username = "testFullName",
                    Cart = new List<Product>()
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

            context.Customers.AddRange(customers);
            context.Products.AddRange(products);
            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
    }
}
