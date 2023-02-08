using ECommerce.Domain.Models.Domain;
using ECommerce.Service.Models;

namespace ECommerce.Service.Services.PriceCalculation
{
    public interface IPriceCalculationService
    {
        OrderPriceCalculationDto CalculateOrderTotalPrice(List<CartItem> cartItems, string phoneNumber);
    }
}