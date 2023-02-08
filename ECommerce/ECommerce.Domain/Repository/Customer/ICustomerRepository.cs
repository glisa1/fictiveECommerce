using ECommerce.Domain.Models.Domain;

namespace ECommerce.Domain.Repository
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int customerId);
    }
}