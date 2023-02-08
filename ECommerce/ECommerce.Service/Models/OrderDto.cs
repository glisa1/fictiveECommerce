namespace ECommerce.Service.Models
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal AppliedDiscount { get; set; }
    }
}
