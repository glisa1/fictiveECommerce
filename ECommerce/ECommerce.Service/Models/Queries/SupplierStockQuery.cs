using MediatR;

namespace ECommerce.Service.Models.Queries
{
    public class SupplierStockQuery : IRequest<int>
    {
        public int ProductId { get; set; }
    }
}
