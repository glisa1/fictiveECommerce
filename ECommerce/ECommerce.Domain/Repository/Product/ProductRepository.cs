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
                throw new Exception("Entity not found.");
            }

            return product;
        }
    }
}
