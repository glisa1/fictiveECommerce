namespace ECommerce.Service.Models
{
    public class OrderPriceCalculationDto
    {
        public decimal OrderTotal { get; set; }
        public decimal DiscountTotal { get; set; }
    }
}
