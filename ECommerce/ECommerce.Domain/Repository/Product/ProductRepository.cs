using ECommerce.Domain.Models.Domain;

namespace ECommerce.Domain.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IApiContext _context;

        public ProductRepository(IApiContext context)
        {
            _context = context;
        }

        public Product GetProduct(int productId)
        {
            var product = _context.Products
                .SingleOrDefault(x => x.Id == productId);

            if (product == null)
            {
                throw new Exception("Product was not found.");
            }

            return product;
        }

        public async Task AdjustProductQuantity(int productId, int quantityTaken)
        {
            var product = GetProduct(productId);

            product.Quantity -= quantityTaken;

            if (product.Quantity < 0)
                product.Quantity = 0;

            await _context.SaveChangesAsync();
        }
    }
}
