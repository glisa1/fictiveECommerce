namespace ECommerce.Service.SupplierStock
{
    public class SupplierStockService : ISupplierStockService
    {
        public int GetQuantityFromSupplierStock(int productId)
        {
            Random random = new Random();

            return productId * random.Next(0, 3);
        }
    }
}
