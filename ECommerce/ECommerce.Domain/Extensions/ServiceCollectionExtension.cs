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
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IApiContext, ApiContext>();
        }
    }
}
