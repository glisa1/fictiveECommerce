﻿using MediatR;
using ECommerce.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Service.Models.Queries;
using ECommerce.Service.Models.Commands;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetShoppingCartContents")]
        public async Task<IActionResult> GetShoppingCartContents(int customerId)
        {
            try
            {
                var result = await _mediator.Send(new ShoppingCartContentQuery { CustomerId = customerId });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddProductToCart")]
        public async Task<IActionResult> AddProductToCart([FromBody] AddProductToCartCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost(Name = "CreateOrder")]
        //public IActionResult CreateOrder([FromBody] CreateOrderModel model)
        //{
        //    try
        //    {
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
