using ECommerce.Service.Models.Queries;
using MediatR;

namespace ECommerce.Service.SupplierStock
{
    public class SupplierStockService : IRequestHandler<SupplierStockQuery, int>
    {
        public async Task<int> Handle(SupplierStockQuery request, CancellationToken cancellationToken)
        {
            Random random = new Random();

            return request.ProductId * random.Next(0, 3);
        }
    }
}
