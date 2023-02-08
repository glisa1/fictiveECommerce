using ECommerce.Domain.Models.Domain;

namespace ECommerce.Service.Models.Mappers
{
    public static class ShoppingCartToDtoMapper
    {
        public static ShoppingCartDto MapToDto(this List<CartItem> cartItems)
        {
            var productsDto = new ShoppingCartDto();

            if (cartItems == null)
                return productsDto;

            foreach (var cartItem in cartItems)
            {
                productsDto.Products.Add(new ProductDto
                {
                    Id = cartItem.Id,
                    Name = cartItem.Product.Name,
                    Price = cartItem.Product.Price,
                    Quantity = cartItem.QuantityInCart,
                });
            }
            
            return productsDto;
        }
    }
}
