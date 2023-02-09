using ECommerce.UnitTests.MockContext;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Tests.RepoTests
{
    [TestClass]
    public class ShoppingCartTest
    {
        private readonly IMockApiContext _apiContext;

        public ShoppingCartTest()
        {
            var provider = ServiceProviderForTests.TestServiceProvider;
            _apiContext = provider.GetService<IMockApiContext>();
        }

        [TestMethod]
        public void FindCart_GetCart_CartFound()
        {
            var customer = _apiContext.Customers.SingleOrDefault(x => x.Id == 1);

            Assert.IsNotNull(customer);
            Assert.IsNotNull(customer.Cart);
            Assert.AreEqual(1, customer.Cart.Count);
            Assert.AreEqual(customer.Cart[0].QuantityInCart, 2);
        }
    }
}
