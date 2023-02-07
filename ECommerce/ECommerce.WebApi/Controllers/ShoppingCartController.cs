using ECommerce.Service.ShoppingCart;
using ECommerce.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet(Name = "GetShoppingCartContents")]
        public IActionResult GetShoppingCartContents(int userId)
        {
            try
            {
                var result = _shoppingCartService.GetCartContent(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddProductToCart")]
        public IActionResult AddProductToCart([FromBody] AddProductToCartModel model)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "CreateOrder")]
        public IActionResult CreateOrder([FromBody] CreateOrderModel model)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
