using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers.Admin;


[Route("api/admin/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetById(int id)
    {
        var result = productService.GetById(id);
        return result.IsSuccess ? Ok(result) : NotFound();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = productService.GetAll();
        return Ok(result);
    }

    [HttpGet]
    [Route("[action]/{categoryId:int}")]
    public IActionResult GetAllByCategoryId(int categoryId)
    {
        var result = productService.GetAllByCategoryId(categoryId);
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public IActionResult Add(ProductDto product)
    {
        var result = productService.Add(product);
        return Ok(result);
    }

    [Authorize]
    [HttpPut]
    public IActionResult Update(ProductDto product)
    {
        var result = productService.Update(product);
        return Ok(result);
    }

    [Authorize]
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var entity = productService.GetById(id);
        var result = productService.Delete(entity.Value.Id);
        return result.IsSuccess ? Ok(result) : NotFound();
    }
}