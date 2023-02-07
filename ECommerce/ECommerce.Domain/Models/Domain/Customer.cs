using ECommerce.Domain.Models.Base;

namespace ECommerce.Domain.Models.Domain
{
    public class Customer : Entity
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public List<Product> Cart { get; set; }
    }
}
