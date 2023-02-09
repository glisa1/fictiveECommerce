using ECommerce.Service.Models;
using ECommerce.Service.Models.Commands;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;
using System.Text.Json;

namespace ECommerce.IntegrationTests
{
    [TestClass]
    public class ApiTests
    {
        private readonly HttpClient _client;
        public ApiTests()
        {
            _client = ClientProvider.HttpClient;
        }

        [TestMethod]
        public async Task GetShoppingCart_ShoppingCartEmpty()
        {
            var response = await _client.GetAsync("api/ShoppingCart/GetShoppingCartContents?customerId=1");
            var stringResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ShoppingCartDto>(stringResult);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Products.Count, 0);
        }

        [TestMethod]
        public async Task InsertToCart_GetCart_ShoppingCartReturned()
        {
            var insertToCartCommand = new AddProductToCartCommand
            {
                CustomerId = 1,
                ProductId = 3,
                Quantity = 2
            };

            var command = JsonSerializer.Serialize(insertToCartCommand);
            var requestContent = new StringContent(command, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/ShoppingCart/AddProductToCart", requestContent);
            response.EnsureSuccessStatusCode();

            var getCartResponse = await _client.GetAsync("api/ShoppingCart/GetShoppingCartContents?customerId=1");
            var stringResult = await getCartResponse.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ShoppingCartDto>(stringResult, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.IsNotNull(result);
            Assert.AreNotEqual(result.Products.Count, 0);
        }

        [TestMethod]
        public async Task BigQuantity_InsertToCart_NotEnoughProductQuantity()
        {
            var insertToCartCommand = new AddProductToCartCommand
            {
                CustomerId = 1,
                ProductId = 1,
                Quantity = 5000
            };

            var command = JsonSerializer.Serialize(insertToCartCommand);
            var requestContent = new StringContent(command, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/ShoppingCart/AddProductToCart", requestContent);
            
            Assert.ThrowsException<HttpRequestException>(() =>
            {
                response.EnsureSuccessStatusCode();
            });
        }

        [TestMethod]
        public async Task AddToCart_CreateOrder_OrderDetailsReturned()
        {
            var insertToCartCommand = new AddProductToCartCommand
            {
                CustomerId = 1,
                ProductId = 1,
                Quantity = 5
            };

            var secondInsertToCartCommand = new AddProductToCartCommand
            {
                CustomerId = 1,
                ProductId = 2,
                Quantity = 3
            };

            var createOrderCommand = new CreateOrderCommand
            {
                CustomerId = 1,
                Address = "Test address",
                PhoneNumber = "+38145786"
            };
            var command = JsonSerializer.Serialize(insertToCartCommand);
            var secondCommand = JsonSerializer.Serialize(secondInsertToCartCommand);
            var orderCommand = JsonSerializer.Serialize(createOrderCommand);

            var requestContent = new StringContent(command, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/ShoppingCart/AddProductToCart", requestContent);
            response.EnsureSuccessStatusCode();

            requestContent = new StringContent(secondCommand, Encoding.UTF8, "application/json");
            response = await _client.PostAsync("api/ShoppingCart/AddProductToCart", requestContent);
            response.EnsureSuccessStatusCode();

            requestContent = new StringContent(orderCommand, Encoding.UTF8, "application/json");
            response = await _client.PostAsync("api/ShoppingCart/CreateOrder", requestContent);
            response.EnsureSuccessStatusCode();
            var stringResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<OrderDto>(stringResult, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.IsNotNull(result);
            Assert.AreNotEqual(result.OrderTotal, 0);
        }

        [TestMethod]
        public async Task AddToCart_CreateOrder_InvalidInput()
        {
            var insertToCartCommand = new AddProductToCartCommand
            {
                CustomerId = 1,
                ProductId = 1,
                Quantity = 5
            };

            var createOrderCommand = new CreateOrderCommand
            {
                CustomerId = 1,
                Address = string.Empty,
                PhoneNumber = "+3814153138549845615685786"
            };
            var command = JsonSerializer.Serialize(insertToCartCommand);
            var orderCommand = JsonSerializer.Serialize(createOrderCommand);

            var requestContent = new StringContent(command, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/ShoppingCart/AddProductToCart", requestContent);
            response.EnsureSuccessStatusCode();

            requestContent = new StringContent(orderCommand, Encoding.UTF8, "application/json");
            response = await _client.PostAsync("api/ShoppingCart/CreateOrder", requestContent);

            Assert.ThrowsException<HttpRequestException>(() =>
            {
                response.EnsureSuccessStatusCode();
            });
        }
    }
}
