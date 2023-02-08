using ECommerce.Domain.Models.Base;

namespace ECommerce.Domain.Models.Domain
{
    public class CartItem : Entity
    {
        public Product Product { get; set; }
        public int QuantityInCart { get; set; }
    }
}
