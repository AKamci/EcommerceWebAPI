using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Infrastructure;
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

        public Result<Product> GetById(int id)
        {
            var entity = _ecommerceContext.Products.Find(id);

            return entity is not null ? Result<Product>.Success(entity,"Product found.") : Result<Product>.Failure("Product not found.");
        }

        public Result<List<Product>> GetAll()
        {
            var entities = _ecommerceContext.Products.ToList();

            if (entities.Count > 0)
            {
                return Result<List<Product>>.Success(entities, "Products found.");
            }

            return Result<List<Product>>.Failure("Products not found.");
        }

        public Result<Product> Add(Product entity)
        {
            _ecommerceContext.Products.Add(entity);
            _ecommerceContext.SaveChanges();

            return Result<Product>.Success(entity, "New Product added.");
        }

        public Result<Product> Update(Product entity)
        {
            _ecommerceContext.Products.Update(entity);
            _ecommerceContext.SaveChanges();

            return Result<Product>.Success(entity, "New Product updated.");
        }

        public Result<bool> Delete(Product entity)
        {
            _ecommerceContext.Products.Remove(entity);
            _ecommerceContext.SaveChanges();

            var result = GetById(entity.Id);

            return result is null ? Result<bool>.Success(true, "Product is deleted.") : Result<bool>.Failure("Product not found.");
        }
    }
}
