using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            var entity = _productService.GetById(id);
            if (entity is null) return NotFound(entity);

            return Ok(entity);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _productService.GetAll();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _productService.Add(product);
            return Ok($"The product {product.Name} {product.Category} is created.");
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            _productService.Update(product);
            return Ok($"The product {product.Name} {product.Category} is updated.");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var entity = _productService.GetById(id);
            _productService.Delete(entity);
            return Ok($"The product {entity.Name} {entity.Category} is deleted");
        }
    }
}
