using ECommerce.Domain.Models.Domain;

namespace ECommerce.Domain.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IApiContext _context;

        public ShoppingCartRepository(IApiContext context)
        {
            _context = context;
        }

        public List<Product> GetShoppingCart(int userId)
        {
            var user = _context.Customers
                .SingleOrDefault(x => x.Id == userId);

            if (user == null)
                throw new Exception("Entity was not found.");

            return user.Cart;
        }

        public async void EmptyShoppingCart(int userId)
        {
            var user = _context.Customers
                .SingleOrDefault(x => x.Id == userId);

            if (user == null) 
                throw new Exception("Entity was not found.");

            user.Cart.Clear();
            await _context.SaveChangesAsync();
        }

        public async Task AddToCart(int userId, Product product, int quantity)
        {
            var user = _context.Customers
                .SingleOrDefault(x => x.Id == 1);

            if (user == null)
                throw new Exception("Entity was not found.");

            if (user.Cart == null)
                user.Cart = new List<Product>();

            user.Cart.Add(product);
            await _context.SaveChangesAsync();
        }
    }
}
