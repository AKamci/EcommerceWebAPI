using Ecommerce.API.Datalayer.Repos.Abstract;
using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete;

public class CartService : ICartService
{
    private readonly ICartRepo _repo;

    public CartService(ICartRepo repo)
    {
        _repo = repo;
    }

    public Result<Cart> GetById(int id)
    {
        var entity = _repo.GetById(id);
        // Cart To CartDTO

        return entity is not null ? Result<Cart>.Success(entity, Messages.Cart.Found) : Result<Cart>.Failure(Messages.Cart.NotFound);
    }

    public Result<List<Cart>> GetAll()
    {
        var entities = _repo.GetAll();

        if (entities.Count > 0)
        {
            return Result<List<Cart>>.Success(entities, Messages.Cart.Found);
        }

        return Result<List<Cart>>.Failure(Messages.Cart.NotFound);
    }

    public Result<Cart> Add(Cart entity)
    {
        _repo.Add(entity);
        return Result<Cart>.Success(entity, Messages.Cart.Added);
    }

    public Result<Cart> Update(Cart entity)
    {
        _repo.Update(entity);

        return Result<Cart>.Success(entity, Messages.Cart.Updated);
    }

    public Result<bool> Delete(Cart entity)
    {
        _repo.Delete(entity.Id);

        var result = GetById(entity.Id);

        return result is null ? Result<bool>.Success(true, Messages.Cart.Deleted) : Result<bool>.Failure(Messages.Cart.NotFound);
    }
}
