﻿using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Dtos;
using Ecommerce.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetById(int id)
    {
        var result = categoryService.GetById(id);
        return result.IsSuccess ? Ok(result) : NotFound();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = categoryService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Add(CategoryCreateDto category)
    {
        var categoryDto = new CategoryDto
        {
            Description = category.Description,
            Name = category.Name,
            IsActive = category.IsActive
        };

        var result = categoryService.Add(categoryDto);
        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(CategoryDto category)
    {
        var result = categoryService.Update(category);
        return Ok(result);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var entity = categoryService.GetById(id);
        var result = categoryService.Delete(entity.Value.Id);
        return result.IsSuccess ? Ok(result) : NotFound();
    }
}