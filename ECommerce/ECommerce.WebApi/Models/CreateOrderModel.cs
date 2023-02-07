namespace ECommerce.WebApi.Models
{
    public class CreateOrderModel
    {
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
