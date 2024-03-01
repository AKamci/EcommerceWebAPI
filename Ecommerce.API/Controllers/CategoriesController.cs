using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetById(int id)
    {
        var result = categoryService.GetById(id);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = categoryService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Add(Category category)
    {
        var result = categoryService.Add(category);
        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(Category category)
    {
        var result = categoryService.Update(category);
        return Ok(result);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var entity = categoryService.GetById(id);
        var result = categoryService.Delete(entity.Value);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }
}