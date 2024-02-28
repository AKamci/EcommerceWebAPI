using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            var entity = _categoryService.GetById(id);
            if (entity is null) return NotFound(entity);

            return Ok(entity);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _categoryService.GetAll();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            _categoryService.Add(category);
            return Ok($"Category named {category.Name} was created.");
        }

        [HttpPut]
        public IActionResult Update(Category category)
        {
            _categoryService.Update(category);
            return Ok($"Category named {category.Name} was updated.");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var entity = _categoryService.GetById(id);
            _categoryService.Delete(entity);
            return Ok($"Category named {entity.Name} was created.");
        }
    }
}
