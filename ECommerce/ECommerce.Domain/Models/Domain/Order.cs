using ECommerce.Domain.Models.Base;

namespace ECommerce.Domain.Models.Domain
{
    public class Order : Entity
    {
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AppliedDiscount { get; set; }
        public string Address { get; set; }
    }
}
