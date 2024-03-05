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

            return entity is not null ? Result<Order>.Success(entity, "Order found.") : Result<Order>.Failure("Order not found.");
        }

        public Result<List<Order>> GetAll()
        {
            var entities = ecommerceContext.Orders.ToList();

            if (entities.Count > 0)
            {
                return Result<List<Order>>.Success(entities, "Order found.");
            }

            return Result<List<Order>>.Failure("Orders not found.");
        }

        public Result<Order> Add(Order entity)
        {
            ecommerceContext.Orders.Add(entity);
            ecommerceContext.SaveChanges();

            return Result<Order>.Success(entity, "New Order added.");
        }

        public Result<Order> Update(Order entity)
        {
            ecommerceContext.Orders.Update(entity);
            ecommerceContext.SaveChanges();

            return Result<Order>.Success(entity, "New Order updated.");
        }

        public Result<bool> Delete(Order entity)
        {
            ecommerceContext.Orders.Remove(entity);
            ecommerceContext.SaveChanges();

            var result = GetById(entity.Id);

            return result is null ? Result<bool>.Success(true, "Order is deleted.") : Result<bool>.Failure("Order not found.");
        }
    }
}
