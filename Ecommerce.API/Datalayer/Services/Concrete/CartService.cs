using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete
{
    public class CartService(EcommerceContext ecommerceContext) : ICartService
    {
        public Result<Cart> GetById(int id)
        {
            var entity = ecommerceContext.Carts.Find(id);

            return entity is not null ? Result<Cart>.Success(entity,"Cart found.") : Result<Cart>.Failure("Cart not found.");
        }

        public Result<List<Cart>> GetAll()
        {
            var entities = ecommerceContext.Carts.ToList();

            if (entities.Count > 0)
            {
                return Result<List<Cart>>.Success(entities, "Carts found.");
            }

            return Result<List<Cart>>.Failure("Carts not found.");
        }

        public Result<Cart> Add(Cart entity)
        {
            ecommerceContext.Carts.Add(entity);
            ecommerceContext.SaveChanges();

            return Result<Cart>.Success(entity, "New Cart added.");
        }

        public Result<Cart> Update(Cart entity)
        {
            ecommerceContext.Carts.Update(entity);
            ecommerceContext.SaveChanges();

            return Result<Cart>.Success(entity, "New Cart updated.");
        }

        public Result<bool> Delete(Cart entity)
        {
            ecommerceContext.Carts.Remove(entity);
            ecommerceContext.SaveChanges();

            var result = GetById(entity.Id);

            return result is null ? Result<bool>.Success(true, "Cart is deleted.") : Result<bool>.Failure("Cart not found.");
        }
    }
}
