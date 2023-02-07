using ECommerce.Domain.Models.Domain;

namespace ECommerce.Domain.Repository
{
    public interface IShoppingCartRepository
    {
        List<Product> GetShoppingCart(int userId);
        void EmptyShoppingCart(int userId);
        void AddToCart(int userId, Product product, int quantity);
    }
}
