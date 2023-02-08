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

        public List<CartItem> GetShoppingCart(Customer customer)
        {
            return customer.Cart;
        }

        public async Task EmptyShoppingCart(Customer customer)
        {
            customer.Cart.Clear();
            await _context.SaveChangesAsync();
        }

        public async Task AddToCart(Customer customer, Product product, int quantity)
        {
            if (customer.Cart == null)
                customer.Cart = new List<CartItem>();

            var itemInCart = customer.Cart.Where(x => x.Product.Id == product.Id).FirstOrDefault();

            if (itemInCart == null)
            {
                customer.Cart.Add(new CartItem
                {
                    Product = product,
                    QuantityInCart = quantity
                });
            }
            else
            {
                itemInCart.QuantityInCart += quantity;
            }
        }
    }
}
