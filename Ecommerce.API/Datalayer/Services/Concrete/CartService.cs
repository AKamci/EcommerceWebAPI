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

            return entity is not null ? Result<Cart>.Success(entity, Messages.Cart.Found) : Result<Cart>.Failure(Messages.Cart.NotFound);
        }

        public Result<List<Cart>> GetAll()
        {
            var entities = ecommerceContext.Carts.ToList();

            if (entities.Count > 0)
            {
                return Result<List<Cart>>.Success(entities, Messages.Cart.Found);
            }

            return Result<List<Cart>>.Failure(Messages.Cart.NotFound);
        }

        public Result<Cart> Add(Cart entity)
        {
            ecommerceContext.Carts.Add(entity);
            ecommerceContext.SaveChanges();

            return Result<Cart>.Success(entity, Messages.Cart.Added);
        }

        public Result<Cart> Update(Cart entity)
        {
            ecommerceContext.Carts.Update(entity);
            ecommerceContext.SaveChanges();

            return Result<Cart>.Success(entity, Messages.Cart.Updated);
        }

        public Result<bool> Delete(Cart entity)
        {
            ecommerceContext.Carts.Remove(entity);
            ecommerceContext.SaveChanges();

            var result = GetById(entity.Id);

            return result is null ? Result<bool>.Success(true, Messages.Cart.Deleted) : Result<bool>.Failure(Messages.Cart.NotFound);
        }
    }
}
