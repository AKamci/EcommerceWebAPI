using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete
{
    public class OrderService(EcommerceContext ecommerceContext) : IOrderService
    {
        public Result<Order> GetById(int id)
        {
            var entity = ecommerceContext.Orders.Find(id);

            return entity is not null ? Result<Order>.Success(entity, Messages.Order.Found) : Result<Order>.Failure(Messages.Order.NotFound);
        }

        public Result<List<Order>> GetAll()
        {
            var entities = ecommerceContext.Orders.ToList();

            if (entities.Count > 0)
            {
                return Result<List<Order>>.Success(entities, Messages.Order.Found);
            }

            return Result<List<Order>>.Failure(Messages.Order.NotFound);
        }

        public Result<Order> Add(Order entity)
        {
            ecommerceContext.Orders.Add(entity);
            ecommerceContext.SaveChanges();

            return Result<Order>.Success(entity, Messages.Order.Added);
        }

        public Result<Order> Update(Order entity)
        {
            ecommerceContext.Orders.Update(entity);
            ecommerceContext.SaveChanges();

            return Result<Order>.Success(entity, Messages.Order.Updated);
        }

        public Result<bool> Delete(Order entity)
        {
            ecommerceContext.Orders.Remove(entity);
            ecommerceContext.SaveChanges();

            var result = GetById(entity.Id);

            return result is null ? Result<bool>.Success(true, Messages.Order.Deleted) : Result<bool>.Failure(Messages.Order.NotFound);
        }
    }
}
