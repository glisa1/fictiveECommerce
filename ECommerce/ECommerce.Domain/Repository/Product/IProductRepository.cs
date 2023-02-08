using ECommerce.Domain.Models.Domain;

namespace ECommerce.Domain.Repository
{
    public interface IProductRepository
    {
        Product GetProduct(int productId);
        Task AdjustProductQuantity(int productId, int quantityTaken);
    }
}
