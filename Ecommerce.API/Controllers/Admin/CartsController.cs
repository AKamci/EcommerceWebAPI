using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Dtos;
using Ecommerce.API.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers.Admin;

[Authorize]
[Route("api/admin/[controller]")]
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
    public IActionResult Add(CartDto cart)
    {
        var result = cartService.Add(cart);
        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(CartDto cart)
    {
        var result = cartService.Update(cart);
        return Ok(result);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var entity = cartService.GetById(id);
        var result = cartService.Delete(entity.Value.Id);
        return result.IsSuccess ? Ok(result) : NotFound();
    }
}