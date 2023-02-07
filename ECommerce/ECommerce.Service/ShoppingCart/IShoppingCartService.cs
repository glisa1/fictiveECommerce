using ECommerce.Service.Models;

namespace ECommerce.Service.ShoppingCart
{
    public interface IShoppingCartService
    {
        ShoppingCartDto GetCartContent(int userId);
    }
}
