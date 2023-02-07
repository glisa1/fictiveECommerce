using ECommerce.Domain.Models.Domain;

namespace ECommerce.Domain.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Product GetProduct(int productId)
        {
            using var context = new ApiContext();

            var product = context.Products
                .SingleOrDefault(x => x.Id == productId);

            if (product == null)
            {
                throw new Exception("Entity not found.");
            }

            return product;
        }
    }
}
