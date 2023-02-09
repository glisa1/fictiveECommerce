using ECommerce.Domain;
using ECommerce.Domain.Models.Domain;
using ECommerce.UnitTests.MockContext;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Tests.RepoTests
{
    [TestClass]
    public class CreatingOrderTest
    {
        private readonly IMockApiContext _apiContext;

        public CreatingOrderTest()
        {
            var provider = ServiceProviderForTests.TestServiceProvider;
            _apiContext = provider.GetService<IMockApiContext>();
        }

        [TestMethod]
        public async Task WithNewCustomer_AddOrder_OrderCreated()
        {
            var newCustomer = new Customer
            {
                Cart = new List<CartItem>(),
                FullName = "Test Full Name",
                Username = "testFullName"
            };

            var newOrder = new Order
            {
                Id = 15,
                Address = "Test address",
                AppliedDiscount = 123m,
                TotalAmount = 560m,
                Customer = newCustomer
            };

            newCustomer.Cart.Add(new CartItem
            {
                QuantityInCart = 2,
                Product = _apiContext.Products.SingleOrDefault(x => x.Id == 2)
            });

            _apiContext.Orders.Add(newOrder);
            await _apiContext.SaveChangesAsync();

            var objToAssert = _apiContext.Orders.SingleOrDefault(x => x.Id == newOrder.Id);

            Assert.IsNotNull(objToAssert);
            Assert.IsNotNull(objToAssert.Customer);
            Assert.AreEqual(objToAssert.Address, newOrder.Address);
            Assert.AreEqual(objToAssert.AppliedDiscount, newOrder.AppliedDiscount);
            Assert.AreEqual(objToAssert.TotalAmount, newOrder.TotalAmount);
        }
    }
}
