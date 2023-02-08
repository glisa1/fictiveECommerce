using ECommerce.Domain.Models.Domain;

namespace ECommerce.Domain.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IApiContext _context;

        public OrderRepository(IApiContext context)
        {
            _context = context;
        }

        public Order CreateOrder(Customer customer, decimal totalAmount, decimal appliedDiscount, string address)
        {
            var newOrder = new Order
            {
                Customer = customer,
                TotalAmount = totalAmount,
                AppliedDiscount = appliedDiscount,
                Address = address
            };

            _context.Orders.Add(newOrder);

            return newOrder;
        }

    }
}
