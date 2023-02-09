using ECommerce.Domain.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.UnitTests.MockContext
{
    public class MockApiContext : DbContext, IMockApiContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public MockApiContext()
        {
            AddMockData();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "DemoDb");
        }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        private async void AddMockData()
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
                    Price = 200m
                },
                new Product
                {
                    Id = 2,
                    Name = "Test product 2",
                    Quantity = 10,
                    Price = 150m
                },
                new Product
                {
                    Id = 3,
                    Name = "Test product 3",
                    Quantity = 10,
                    Price = 100m
                },
                new Product
                {
                    Id = 4,
                    Name = "Test product 4",
                    Quantity = 10,
                    Price = 50m
                }
            };

            var orders = new List<Order>();
            Products.AddRange(products);
            Orders.AddRange(orders);
            Customers.AddRange(customers);

            var customer = customers.SingleOrDefault(x => x.Id == 1);
            customer.Cart.Add(new CartItem
            {
                QuantityInCart = 2,
                Product = Products.SingleOrDefault(x => x.Id == 1)
            });

            await SaveChangesAsync();
        }
    }
}
