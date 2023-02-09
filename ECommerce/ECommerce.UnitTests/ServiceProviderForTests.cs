using ECommerce.Service.Services.PriceCalculation;
using ECommerce.UnitTests.MockContext;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Tests
{
    public static class ServiceProviderForTests
    {
        public static IServiceProvider TestServiceProvider
        {
            get
            {
                if (_serviceProvider == null)
                    _serviceProvider = GetServiceProvider();

                return _serviceProvider;
            }
        }

        private static IServiceProvider _serviceProvider;

        private static IServiceProvider GetServiceProvider()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<IMockApiContext, MockApiContext>();
            services.AddTransient<IPriceCalculationService, PriceCalculationService>();

            return services.BuildServiceProvider();
        }
    }
}
