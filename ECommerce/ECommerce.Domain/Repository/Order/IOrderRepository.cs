using ECommerce.Domain.Models.Domain;

namespace ECommerce.Domain.Repository
{
    public interface IOrderRepository
    {
        Order CreateOrder(Customer customer, decimal totalAmount, decimal appliedDiscount, string address);
    }
}
