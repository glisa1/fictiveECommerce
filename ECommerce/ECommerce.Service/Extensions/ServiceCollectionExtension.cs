using MediatR;
using FluentValidation;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ECommerce.Service.Services.PriceCalculation;
using FluentValidation.AspNetCore;

namespace ECommerce.Service.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IPriceCalculationService, PriceCalculationService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
