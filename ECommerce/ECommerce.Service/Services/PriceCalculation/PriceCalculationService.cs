using ECommerce.Domain.Models.Domain;
using ECommerce.Service.Extensions;
using ECommerce.Service.Models;

namespace ECommerce.Service.Services.PriceCalculation
{
    public class PriceCalculationService : IPriceCalculationService
    {
        public OrderPriceCalculationDto CalculateOrderTotalPrice(List<CartItem> cartItems, string phoneNumber)
        {
            var orderTotal = decimal.Zero;
            var discountTotal = decimal.Zero;
            var discountToApply = GetDiscountPercent(phoneNumber);

            foreach (var cartItem in cartItems)
            {
                orderTotal += cartItem.QuantityInCart * cartItem.Product.Price;
            }

            if (discountToApply > decimal.Zero)
            {
                discountTotal = orderTotal * discountToApply;
                orderTotal -= discountTotal;
            }

            return new OrderPriceCalculationDto
            {
                OrderTotal = orderTotal,
                DiscountTotal = discountTotal,
            };
        }

        private decimal GetDiscountPercent(string phoneNumber)
        {
            if (!DateTime.Now.GetHappyHourDiscount())
                return decimal.Zero;

            var lastDigit = GetLastDigitFromNumber(phoneNumber);

            if (lastDigit == 0)
                return 0.3m;

            if (lastDigit % 2 == 0)
            {
                return 0.2m;
            }
            else
            {
                return 0.1m;
            }
        }

        private int GetLastDigitFromNumber(string phoneNumber)
        {
            return int.Parse(phoneNumber.Substring(phoneNumber.Length - 1, 1));
        }
    }
}
