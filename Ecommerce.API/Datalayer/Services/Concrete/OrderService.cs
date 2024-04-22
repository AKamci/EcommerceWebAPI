using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Datalayer.Services.Mapping;
using Ecommerce.API.Dtos;
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

    public Result<OrderDto> GetById(int id)
    {
        var entity = _unitOfWork.OrderRepo.GetById(id);
        // Order To OrderDTO
        var orderDto = ObjectMapper.Mapper.Map<OrderDto>(entity);
        return entity is not null ? Result<OrderDto>.Success(orderDto, Messages.Order.Found) : Result<OrderDto>.Failure(Messages.Order.NotFound);
    }

    public Result<List<OrderDto>> GetAll()
    {
        var entities = _unitOfWork.OrderRepo.GetAll();

        if (entities.Count > 0)
        {
            var dtoList = ObjectMapper.Mapper.Map<List<OrderDto>>(entities);
            return Result<List<OrderDto>>.Success(dtoList, Messages.Order.Found);
        }

        return Result<List<OrderDto>>.Failure(Messages.Order.NotFound);
    }

    public Result<OrderDto> Add(OrderDto entity)
    {
        var order = ObjectMapper.Mapper.Map<Order>(entity);
        _unitOfWork.OrderRepo.Add(order);
        _unitOfWork.SaveChanges();
        var lastDto = ObjectMapper.Mapper.Map<OrderDto>(entity);

        return Result<OrderDto>.Success(lastDto, Messages.Order.Added);
    }

    public Result<OrderDto> Update(OrderDto entity)
    {
        var order = ObjectMapper.Mapper.Map<Order>(entity);
        _unitOfWork.OrderRepo.Update(order);
        _unitOfWork.SaveChanges();
        var lastDto = ObjectMapper.Mapper.Map<OrderDto>(entity);

        return Result<OrderDto>.Success(lastDto, Messages.Order.Updated);
    }

    public Result<bool> Delete(int id)
    {
        _unitOfWork.OrderRepo.Delete(id);

        var result = GetById(id);
        _unitOfWork.SaveChanges();
        return result is null ? Result<bool>.Success(true, Messages.Order.Deleted) : Result<bool>.Failure(Messages.Order.NotFound);
    }
}
