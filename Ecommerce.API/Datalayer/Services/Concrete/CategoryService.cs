using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Datalayer.Services.Mapping;
using Ecommerce.API.Dtos;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete;

public class CategoryService(UnitOfWork unitOfWork) : ICategoryService
{



    public Result<CategoryDto> GetById(int id)
    {
        var entity = unitOfWork.CategoryRepo.GetById(id);

        var categoryDto = ObjectMapper.Mapper.Map<CategoryDto>(entity);
        return entity is not null ? Result<CategoryDto>.Success(categoryDto, Messages.Cart.Found) : Result<CategoryDto>.Failure(Messages.Cart.NotFound);
    }

    public Result<List<CategoryDto>> GetAll()
    {
        var entities = unitOfWork.CategoryRepo.GetAll();

        
        if (entities.Count > 0)
        {
            var dtoList = ObjectMapper.Mapper.Map<List<CategoryDto>>(entities);
            return Result<List<CategoryDto>>.Success(dtoList, Messages.Category.Found);
        }

        return Result<List<CategoryDto>>.Failure(Messages.Category.NotFound);
    }

    public Result<CategoryDto> Add(CategoryDto entity)
    {
        var category = ObjectMapper.Mapper.Map<Category>(entity);
        unitOfWork.CategoryRepo.Add(category);
        unitOfWork.SaveChanges();
        var lastDto = ObjectMapper.Mapper.Map<CategoryDto>(entity);

        return Result<CategoryDto>.Success(lastDto, Messages.Category.Added);
    }

    public Result<CategoryDto> Update(CategoryDto entity)
    {
        var category = ObjectMapper.Mapper.Map<Category>(entity);
        unitOfWork.CategoryRepo.Update(category);
        unitOfWork.SaveChanges();
        var lastDto = ObjectMapper.Mapper.Map<CategoryDto>(entity);
        return Result<CategoryDto>.Success(lastDto, Messages.Category.Updated);
    }

    public Result<bool> Delete(int id)
    {
        unitOfWork.CategoryRepo.Delete(id);
        
        var result = GetById(id);
        unitOfWork.SaveChanges();

        return result is null ? Result<bool>.Success(true, Messages.Category.Deleted) : Result<bool>.Failure(Messages.Category.NotFound);
    }
}
