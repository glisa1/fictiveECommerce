namespace ECommerce.WebApi.Models
{
    public class AddProductToCartModel
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
