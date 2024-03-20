using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Datalayer.Services.Concrete
{
    public class ProductService(EcommerceContext ecommerceContext) : IProductService
    {
        public Result<Product> GetById(int id)
        {
            var entity = ecommerceContext.Products.Find(id);

            return entity is not null ? Result<Product>.Success(entity,Messages.Product.Found) : Result<Product>.Failure(Messages.Product.NotFound);
        }

        public Result<List<Product>> GetAll()
        {
            // Eager loading is implemented
            var entities = ecommerceContext
                .Products
                .Include(i => i.Category)
                .ToList();

            if (entities.Count > 0)
            {
                return Result<List<Product>>.Success(entities, Messages.Product.Found);
            }

            return Result<List<Product>>.Failure(Messages.Product.NotFound);
        }

        public Result<Product> Add(Product entity)
        {
            ecommerceContext.Products.Add(entity);
            ecommerceContext.SaveChanges();

            return Result<Product>.Success(entity, Messages.Product.Added);
        }

        public Result<Product> Update(Product entity)
        {
            ecommerceContext.Products.Update(entity);
            ecommerceContext.SaveChanges();

            return Result<Product>.Success(entity, Messages.Product.Updated);
        }

        public Result<bool> Delete(Product entity)
        {
            ecommerceContext.Products.Remove(entity);
            ecommerceContext.SaveChanges();

            var result = GetById(entity.Id);

            return result is null ? Result<bool>.Success(true, Messages.Product.Deleted) : Result<bool>.Failure(Messages.Product.NotFound);
        }
    }
}
