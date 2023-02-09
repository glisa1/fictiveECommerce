using ECommerce.Domain.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.UnitTests.MockContext
{
    public interface IMockApiContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }

        Task SaveChangesAsync();
    }
}