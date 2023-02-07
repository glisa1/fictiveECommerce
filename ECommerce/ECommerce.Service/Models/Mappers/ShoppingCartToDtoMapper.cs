using ECommerce.Domain.Models.Domain;

namespace ECommerce.Service.Models.Mappers
{
    public static class ShoppingCartToDtoMapper
    {
        public static ShoppingCartDto MapToDto(this List<Product> products)
        {
            var productsDto = new ShoppingCartDto();

            if (products == null)
                return productsDto;

            foreach (var product in products)
            {
                productsDto.Products.Add(new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                });
            }
            
            return productsDto;
        }
    }
}
