using MediatR;

namespace ECommerce.Service.Models.Queries
{
    public class ShoppingCartContentQuery : IRequest<ShoppingCartDto>
    {
        public int CustomerId { get; set; }
    }
}
