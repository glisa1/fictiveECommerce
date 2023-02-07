using ECommerce.Service.ShoppingCart;
using ECommerce.Service.SupplierStock;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Service.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddTransient<ISupplierStockService, SupplierStockService>();
        }
    }
}
