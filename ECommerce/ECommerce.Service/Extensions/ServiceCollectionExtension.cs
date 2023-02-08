using MediatR;
using System.Reflection;
using ECommerce.Service.SupplierStock;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Service.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<ISupplierStockService, SupplierStockService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
