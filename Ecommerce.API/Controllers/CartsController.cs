using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

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
        var result = _cartService.GetById(id);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _cartService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Add(Cart cart)
    {
        var result = _cartService.Add(cart);
        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(Cart cart)
    {
        var result = _cartService.Update(cart);
        return Ok(result);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var entity = _cartService.GetById(id);
        var result = _cartService.Delete(entity.Value);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }
}