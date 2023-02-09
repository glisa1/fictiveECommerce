using ECommerce.Domain;
using ECommerce.Domain.Models.Domain;
using ECommerce.UnitTests.MockContext;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Tests.RepoTests
{
    [TestClass]
    public class AddingProductToCartTest
    {
        private readonly IMockApiContext _apiContext;

        public AddingProductToCartTest()
        {
            var provider = ServiceProviderForTests.TestServiceProvider;
            _apiContext = provider.GetService<IMockApiContext>();
        }

        [TestMethod]
        public async Task NewProduct_AddProduct_ProductAdded()
        {
            var newProduct = new Product
            {
                Id = 5,
                Name = "Product #6",
                Price = 155m,
                Quantity = 20
            };

            _apiContext.Products.Add(newProduct);
            await _apiContext.SaveChangesAsync();

            var objToAssert = _apiContext.Products.SingleOrDefault(x => x.Id == newProduct.Id);

            Assert.IsNotNull(objToAssert);
            Assert.AreEqual(objToAssert.Price, newProduct.Price);
            Assert.AreEqual(objToAssert.Name, newProduct.Name);
            Assert.AreEqual(objToAssert.Quantity, newProduct.Quantity);
        }
    }
}
