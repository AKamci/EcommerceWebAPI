using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Services.Abstract;
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

        public Cart GetById(int id)
        {
            return _ecommerceContext.Carts.Find(id);
        }

        public List<Cart> GetAll()
        {
            return _ecommerceContext.Carts.ToList();
        }

        public void Add(Cart entity)
        {
            _ecommerceContext.Carts.Add(entity);
            _ecommerceContext.SaveChanges();
        }

        public void Update(Cart entity)
        {
            _ecommerceContext.Carts.Update(entity);
            _ecommerceContext.SaveChanges();
        }

        public void Delete(Cart entity)
        {
            _ecommerceContext.Carts.Remove(entity);
            _ecommerceContext.SaveChanges();
        }

        public void SpecificMethodForCart()
        {
            throw new NotImplementedException();
        }
    }
}
