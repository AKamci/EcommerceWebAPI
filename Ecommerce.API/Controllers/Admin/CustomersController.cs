using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers.Admin;

[Authorize]
[Route("api/admin/[controller]")]
[ApiController]
public class CustomersController(ICustomerService userService) : ControllerBase
{
    [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetById(int id)
    {
        var result = userService.GetById(id);
        return result.IsSuccess ? Ok(result) : NotFound();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = userService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Add(CustomerDto user)
    {
        var result = userService.Add(user);
        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(CustomerDto user)
    {
        var result = userService.Update(user);
        return Ok(result);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var entity = userService.GetById(id);
        var result = userService.Delete(entity.Value.Id);
        return result.IsSuccess ? Ok(result) : NotFound();
    }
}