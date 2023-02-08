using MediatR;

namespace ECommerce.Service.Models.Commands
{
    public class CreateOrderCommand : IRequest<OrderDto>
    {
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
