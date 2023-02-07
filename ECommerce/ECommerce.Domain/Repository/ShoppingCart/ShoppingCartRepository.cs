using ECommerce.Domain.Models.Domain;

namespace ECommerce.Domain.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        public List<Product> GetShoppingCart(int userId)
        {
            using var context = new ApiContext();

            var user = context.Customers
                .SingleOrDefault(x => x.Id == userId);

            if (user == null)
                throw new Exception("Entity was not found.");

            return user.Cart;
        }

        public void EmptyShoppingCart(int userId)
        {
            using var context = new ApiContext();

            var user = context.Customers
                .SingleOrDefault(x => x.Id == userId);

            if (user == null) 
                throw new Exception("Entity was not found.");

            user.Cart.Clear();
            context.SaveChanges();

        }

        public void AddToCart(int userId, Product product, int quantity)
        {
            using var context = new ApiContext();

            var user = context.Customers
                .SingleOrDefault(x => x.Id == 1);

            if (user == null)
                throw new Exception("Entity was not found.");

            user.Cart.Add(product);
            context.SaveChanges();
        }
    }
}
