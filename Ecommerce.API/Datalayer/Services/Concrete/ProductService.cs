using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly EcommerceContext _ecommerceContext;

        public ProductService(EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public Product GetById(int id)
        {
            return _ecommerceContext.Products.Find(id);
        }

        public List<Product> GetAll()
        {
            return _ecommerceContext.Products.ToList();
        }

        public void Add(Product entity)
        {
            _ecommerceContext.Products.Add(entity);
            _ecommerceContext.SaveChanges();
        }

        public void Update(Product entity)
        {
            _ecommerceContext.Products.Update(entity);
            _ecommerceContext.SaveChanges();
        }

        public void Delete(Product entity)
        {
            _ecommerceContext.Products.Remove(entity);
            _ecommerceContext.SaveChanges();
        }
    }
}
