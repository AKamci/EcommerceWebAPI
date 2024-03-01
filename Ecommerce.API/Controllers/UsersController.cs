using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetById(int id)
    {
        var result = userService.GetById(id);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = userService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Add(User user)
    {
        var result = userService.Add(user);
        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(User user)
    {
        var result = userService.Update(user);
        return Ok(result);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var entity = userService.GetById(id);
        var result = userService.Delete(entity.Value);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }
}