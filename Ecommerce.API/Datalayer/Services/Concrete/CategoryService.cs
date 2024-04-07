using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Repos.Abstract;
using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepo _repo;

    public CategoryService(ICategoryRepo repo)
    {
        _repo = repo;
    }

    public Result<Category> GetById(int id)
    {
        var entity = _repo.GetById(id);
        // Cart To CartDTO

        return entity is not null ? Result<Category>.Success(entity, Messages.Cart.Found) : Result<Category>.Failure(Messages.Cart.NotFound);
    }

    public Result<List<Category>> GetAll()
    {
        var entities = _repo.GetAll();

        if (entities.Count > 0)
        {
            return Result<List<Category>>.Success(entities, Messages.Category.Found);
        }

        return Result<List<Category>>.Failure(Messages.Category.NotFound);
    }

    public Result<Category> Add(Category entity)
    {
        _repo.Add(entity);
        return Result<Category>.Success(entity, Messages.Category.Added);
    }

    public Result<Category> Update(Category entity)
    {
        _repo.Update(entity);

        return Result<Category>.Success(entity, Messages.Category.Updated);
    }

    public Result<bool> Delete(Category entity)
    {
        _repo.Delete(entity.Id);

        var result = GetById(entity.Id);

        return result is null ? Result<bool>.Success(true, Messages.Category.Deleted) : Result<bool>.Failure(Messages.Category.NotFound);
    }
}
