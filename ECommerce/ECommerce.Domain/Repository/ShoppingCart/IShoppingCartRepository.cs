using ECommerce.Domain.Models.Domain;

namespace ECommerce.Domain.Repository
{
    public interface IShoppingCartRepository
    {
        List<CartItem> GetShoppingCart(Customer customer);
        Task EmptyShoppingCart(Customer customer);
        Task AddToCart(Customer customer, Product product, int quantity);
    }
}
