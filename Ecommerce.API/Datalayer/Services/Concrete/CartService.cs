using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete
{
    public class CartService : ICartService
    {
        private readonly EcommerceContext _ecommerceContext;

        public CartService(EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public Result<Cart> GetById(int id)
        {
            var entity = _ecommerceContext.Carts.Find(id);

            return entity is not null ? Result<Cart>.Success(entity,"Cart found.") : Result<Cart>.Failure("Cart not found.");
        }

        public Result<List<Cart>> GetAll()
        {
            var entities = _ecommerceContext.Carts.ToList();

            if (entities.Count > 0)
            {
                return Result<List<Cart>>.Success(entities, "Carts found.");
            }

            return Result<List<Cart>>.Failure("Carts not found.");
        }

        public Result<Cart> Add(Cart entity)
        {
            _ecommerceContext.Carts.Add(entity);
            _ecommerceContext.SaveChanges();

            return Result<Cart>.Success(entity, "New Cart added.");
        }

        public Result<Cart> Update(Cart entity)
        {
            _ecommerceContext.Carts.Update(entity);
            _ecommerceContext.SaveChanges();

            return Result<Cart>.Success(entity, "New Cart updated.");
        }

        public Result<bool> Delete(Cart entity)
        {
            _ecommerceContext.Carts.Remove(entity);
            _ecommerceContext.SaveChanges();

            var result = GetById(entity.Id);

            return result is null ? Result<bool>.Success(true, "Cart is deleted.") : Result<bool>.Failure("Cart not found.");
        }
    }
}
