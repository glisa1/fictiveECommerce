using ECommerce.Service.Extensions;
using ECommerce.Domain.Models.Domain;
using Microsoft.Extensions.DependencyInjection;
using ECommerce.Service.Services.PriceCalculation;
using ECommerce.Tests;

namespace ECommerce.Tests.UnitTests
{
    [TestClass]
    public class OrderCalculationUnitTest
    {
        private readonly IPriceCalculationService _priceCalculationService;

        public OrderCalculationUnitTest()
        {
            var provider = ServiceProviderForTests.TestServiceProvider;
            _priceCalculationService = provider.GetService<IPriceCalculationService>();
        }

        [TestMethod]
        public async Task WithNoDiscount_CalculateOrderTotalPrice_ReturnsOrderTotalAndZeroDiscount()
        {
            var phoneNumber = "+38164646464";
            var cartList = new List<CartItem>
            {
                new CartItem
                {
                    Id = 1,
                    QuantityInCart = 2,
                    Product = new Product
                    {
                        Id = 1,
                        Name = "Test product 1",
                        Price = 100m,
                        Quantity = 10
                    }
                },
                new CartItem
                {
                    Id = 2,
                    QuantityInCart = 2,
                    Product = new Product
                    {
                        Id = 2,
                        Name = "Test product 2",
                        Price = 50m,
                        Quantity = 10
                    }
                }
            };

            var result = _priceCalculationService.CalculateOrderTotalPrice(cartList, phoneNumber);

            if (!DateTime.Now.GetHappyHourDiscount())
            {
                Assert.AreEqual(result.OrderTotal, 300m);
                Assert.AreEqual(result.DiscountTotal, decimal.Zero);
            }
            else
            {
                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public async Task WithOddNumberAsLastDiscount_CalculateOrderTotalPrice_ReturnsOrderTotalAndZeroDiscount()
        {
            var phoneNumber = "+38164646463";
            var cartList = new List<CartItem>
            {
                new CartItem
                {
                    Id = 1,
                    QuantityInCart = 2,
                    Product = new Product
                    {
                        Id = 1,
                        Name = "Test product 1",
                        Price = 100m,
                        Quantity = 10
                    }
                },
                new CartItem
                {
                    Id = 2,
                    QuantityInCart = 2,
                    Product = new Product
                    {
                        Id = 2,
                        Name = "Test product 2",
                        Price = 50m,
                        Quantity = 10
                    }
                }
            };

            var result = _priceCalculationService.CalculateOrderTotalPrice(cartList, phoneNumber);

            if (!DateTime.Now.GetHappyHourDiscount())
            {
                Assert.AreEqual(result.OrderTotal, 300m);
                Assert.AreEqual(result.DiscountTotal, decimal.Zero);
            }
            else
            {
                Assert.IsNotNull(result);
                Assert.AreEqual(result.OrderTotal, 270m);
                Assert.AreEqual(result.DiscountTotal, 30m);
            }
        }

        [TestMethod]
        public async Task WithEvenNumberAsLastDiscount_CalculateOrderTotalPrice_ReturnsOrderTotalAndZeroDiscount()
        {
            var phoneNumber = "+38164646463";
            var cartList = new List<CartItem>
            {
                new CartItem
                {
                    Id = 1,
                    QuantityInCart = 2,
                    Product = new Product
                    {
                        Id = 1,
                        Name = "Test product 1",
                        Price = 100m,
                        Quantity = 10
                    }
                },
                new CartItem
                {
                    Id = 2,
                    QuantityInCart = 2,
                    Product = new Product
                    {
                        Id = 2,
                        Name = "Test product 2",
                        Price = 50m,
                        Quantity = 10
                    }
                }
            };

            var result = _priceCalculationService.CalculateOrderTotalPrice(cartList, phoneNumber);

            if (!DateTime.Now.GetHappyHourDiscount())
            {
                Assert.AreEqual(result.OrderTotal, 300m);
                Assert.AreEqual(result.DiscountTotal, decimal.Zero);
            }
            else
            {
                Assert.IsNotNull(result);
                Assert.AreEqual(result.OrderTotal, 240m);
                Assert.AreEqual(result.DiscountTotal, 60m);
            }
        }

        [TestMethod]
        public async Task WithZeroAsLastNumberDiscount_CalculateOrderTotalPrice_ReturnsOrderTotalAndZeroDiscount()
        {
            var phoneNumber = "+38164646463";
            var cartList = new List<CartItem>
            {
                new CartItem
                {
                    Id = 1,
                    QuantityInCart = 2,
                    Product = new Product
                    {
                        Id = 1,
                        Name = "Test product 1",
                        Price = 100m,
                        Quantity = 10
                    }
                },
                new CartItem
                {
                    Id = 2,
                    QuantityInCart = 2,
                    Product = new Product
                    {
                        Id = 2,
                        Name = "Test product 2",
                        Price = 50m,
                        Quantity = 10
                    }
                }
            };

            var result = _priceCalculationService.CalculateOrderTotalPrice(cartList, phoneNumber);

            if (!DateTime.Now.GetHappyHourDiscount())
            {
                Assert.AreEqual(result.OrderTotal, 300m);
                Assert.AreEqual(result.DiscountTotal, decimal.Zero);
            }
            else
            {
                Assert.IsNotNull(result);
                Assert.AreEqual(result.OrderTotal, 210m);
                Assert.AreEqual(result.DiscountTotal, 90m);
            }
        }
    }
}