using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Repos.Abstract;
using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Dtos;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete;

public class OrderService : IOrderService
{
    private readonly IOrderRepo _repo;

    public OrderService(IOrderRepo repo)
    {
        _repo = repo;
    }

    public Result<Order> GetById(int id)
    {
        var entity = _repo.GetById(id);
        // Cart To CartDTO

        return entity is not null ? Result<Order>.Success(entity, Messages.Order.Found) : Result<Order>.Failure(Messages.Order.NotFound);
    }

    public Result<List<Order>> GetAll()
    {
        var entities = _repo.GetAll();

        if (entities.Count > 0)
        {
            return Result<List<Order>>.Success(entities, Messages.Order.Found);
        }

        return Result<List<Order>>.Failure(Messages.Order.NotFound);
    }

    public Result<Order> Add(Order entity)
    {
        _repo.Add(entity);
        return Result<Order>.Success(entity, Messages.Order.Added);
    }

    public Result<Order> Update(Order entity)
    {
        _repo.Update(entity);

        return Result<Order>.Success(entity, Messages.Order.Updated);
    }

    public Result<bool> Delete(Order entity)
    {
        _repo.Delete(entity.Id);

        var result = GetById(entity.Id);

        return result is null ? Result<bool>.Success(true, Messages.Order.Deleted) : Result<bool>.Failure(Messages.Order.NotFound);
    }
}
