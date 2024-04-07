using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Repos.Abstract;
using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Datalayer.Services.Concrete;

public class ProductService : IProductService
{
 
    private readonly IProductRepo _repo;

    public ProductService(IProductRepo repo)
    {
        _repo = repo;
    }

    public Result<User> GetById(int id)
    {
        var entity = _repo.GetById(id);
        // Cart To CartDTO

        return entity is not null ? Result<User>.Success(entity, Messages.Product.Found) : Result<User>.Failure(Messages.Product.NotFound);
    }

    public Result<List<User>> GetAll()
    {
        var entities = _repo.GetAll();

        if (entities.Count > 0)
        {
            return Result<List<User>>.Success(entities, Messages.Product.Found);
        }

        return Result<List<User>>.Failure(Messages.Product.NotFound);
    }

    public Result<User> Add(User entity)
    {
        _repo.Add(entity);
        return Result<User>.Success(entity, Messages.Product.Added);
    }

    public Result<User> Update(User entity)
    {
        _repo.Update(entity);

        return Result<User>.Success(entity, Messages.Product.Updated);
    }

    public Result<bool> Delete(User entity)
    {
        _repo.Delete(entity.Id);

        var result = GetById(entity.Id);

        return result is null ? Result<bool>.Success(true, Messages.Product.Deleted) : Result<bool>.Failure(Messages.Product.NotFound);
    }
}
