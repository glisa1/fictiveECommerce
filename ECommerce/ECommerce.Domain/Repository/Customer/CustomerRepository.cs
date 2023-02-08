using ECommerce.Domain.Models.Domain;

namespace ECommerce.Domain.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IApiContext _context;

        public CustomerRepository(IApiContext context)
        {
            _context = context;
        }

        public Customer GetCustomer(int customerId)
        {
            var user = _context.Customers
                .SingleOrDefault(x => x.Id == customerId);

            if (user == null)
                throw new Exception("Customer was not found.");

            return user;
        }
    }
}
