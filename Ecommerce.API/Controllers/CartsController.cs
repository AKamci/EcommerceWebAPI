using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartsController(ICartService cartService) : ControllerBase
{
    [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetById(int id)
    {
        var result = cartService.GetById(id);
        return result.IsSuccess ? Ok(result) : NotFound();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = cartService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Add(Cart cart)
    {
        var result = cartService.Add(cart);
        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(Cart cart)
    {
        var result = cartService.Update(cart);
        return Ok(result);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var entity = cartService.GetById(id);
        var result = cartService.Delete(entity.Value);
        return result.IsSuccess ? Ok(result) : NotFound();
    }
}