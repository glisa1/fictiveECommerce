using MediatR;

namespace ECommerce.Service.Models.Commands
{
    public class AddProductToCartCommand : IRequest<int>
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
