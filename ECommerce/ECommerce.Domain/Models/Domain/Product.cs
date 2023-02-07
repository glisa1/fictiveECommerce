using ECommerce.Domain.Models.Base;

namespace ECommerce.Domain.Models.Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
