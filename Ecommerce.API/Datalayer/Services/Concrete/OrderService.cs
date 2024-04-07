using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete;

public class OrderService : IOrderService
{
    private readonly UnitOfWork _unitOfWork;

    public OrderService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Result<Order> GetById(int id)
    {
        var entity = _unitOfWork.OrderRepo.GetById(id);
        // Order To OrderDTO

        return entity is not null ? Result<Order>.Success(entity, Messages.Order.Found) : Result<Order>.Failure(Messages.Order.NotFound);
    }

    public Result<List<Order>> GetAll()
    {
        var entities = _unitOfWork.OrderRepo.GetAll();

        if (entities.Count > 0)
        {
            return Result<List<Order>>.Success(entities, Messages.Order.Found);
        }

        return Result<List<Order>>.Failure(Messages.Order.NotFound);
    }

    public Result<Order> Add(Order entity)
    {
        _unitOfWork.OrderRepo.Add(entity);
        _unitOfWork.SaveChanges();
        return Result<Order>.Success(entity, Messages.Order.Added);
    }

    public Result<Order> Update(Order entity)
    {
        _unitOfWork.OrderRepo.Update(entity);
        _unitOfWork.SaveChanges();
        return Result<Order>.Success(entity, Messages.Order.Updated);
    }

    public Result<bool> Delete(Order entity)
    {
        _unitOfWork.OrderRepo.Delete(entity.Id);

        var result = GetById(entity.Id);
        _unitOfWork.SaveChanges();
        return result is null ? Result<bool>.Success(true, Messages.Order.Deleted) : Result<bool>.Failure(Messages.Order.NotFound);
    }
}
