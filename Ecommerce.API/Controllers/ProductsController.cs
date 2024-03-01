using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetById(int id)
    {
        var result = productService.GetById(id);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = productService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Add(Product product)
    {
        var result = productService.Add(product);
        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(Product product)
    {
        var result = productService.Update(product);
        return Ok(result);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var entity = productService.GetById(id);
        var result = productService.Delete(entity.Value);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }
}