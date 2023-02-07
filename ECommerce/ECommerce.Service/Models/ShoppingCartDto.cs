namespace ECommerce.Service.Models
{
    public class ShoppingCartDto
    {
        public ShoppingCartDto()
        {
            Products = new List<ProductDto>();
        }

        public List<ProductDto> Products { get; set; }
    }
}
