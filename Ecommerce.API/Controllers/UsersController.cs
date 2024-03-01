using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetById(int id)
    {
        var entity = _userService.GetById(id);
        if (entity is null) return NotFound();

        return Ok(entity);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var list = _userService.GetAll();
        return Ok(list);
    }

    [HttpPost]
    public IActionResult Add(User user)
    {
        _userService.Add(user);
        return Ok($"The user {user.Name} {user.Surname} is created.");
    }

    [HttpPut]
    public IActionResult Update(User user)
    {
        _userService.Update(user);
        return Ok($"The user is {user.Name} {user.Surname} updated.");
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var entity = _userService.GetById(id);
        _userService.Delete(entity);
        return Ok($"The user {entity.Name} {entity.Surname} is deleted.");
    }
}