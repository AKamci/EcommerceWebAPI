using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            var entity = _cartService.GetById(id);
            if (entity is null) return NotFound(entity);

            return Ok(entity);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _cartService.GetAll();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult Add(Cart cart)
        {
            _cartService.Add(cart);
            return Ok($"The cart is created.");
        }

        [HttpPut]
        public IActionResult Update(Cart cart)
        {
            _cartService.Update(cart);
            return Ok($"The cart is updated.");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var entity = _cartService.GetById(id);
            _cartService.Delete(entity);
            return Ok($"The cart is deleted.");
        }

    }
}
