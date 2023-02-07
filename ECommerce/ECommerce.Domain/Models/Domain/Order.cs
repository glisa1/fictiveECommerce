using ECommerce.Domain.Models.Base;

namespace ECommerce.Domain.Models.Domain
{
    public class Order : Entity
    {
        public List<Product> Products { get; set; }
        public Customer Customer { get; set; }
    }
}
