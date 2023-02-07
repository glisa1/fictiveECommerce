using ECommerce.Domain.Repository;
using ECommerce.Service.Models;
using ECommerce.Service.Models.Mappers;

namespace ECommerce.Service.ShoppingCart
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public ShoppingCartDto GetCartContent(int userId)
        {
            try
            {
                return _shoppingCartRepository
                        .GetShoppingCart(userId)
                        .MapToDto();
            }
            catch
            {
                throw;
            }
        }

        public void InsertProductToCart(int customerId, int productId, int quantity)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch
            {
                throw;
            }
        }

        public void CreateOrder(int customerId, string address, string phoneNumber)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch
            {
                throw;
            }
        }
    }
}
