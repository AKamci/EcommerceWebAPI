using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete
{
    public class CategoryService(EcommerceContext ecommerceContext) : ICategoryService
    {
        public Result<Category> GetById(int id)
        {
            var entity = ecommerceContext.Categories.Find(id);

            return entity is not null ? Result<Category>.Success(entity,Messages.Category.Found) : Result<Category>.Failure(Messages.Category.NotFound);
        }

        public Result<List<Category>> GetAll()
        {
            var entities = ecommerceContext.Categories.ToList();

            if (entities.Count > 0)
            {
                return Result<List<Category>>.Success(entities, Messages.Category.Found);
            }

            return Result<List<Category>>.Failure(Messages.Category.NotFound);
        }

        public Result<Category> Add(Category entity)
        {
            ecommerceContext.Categories.Add(entity);
            ecommerceContext.SaveChanges();

            return Result<Category>.Success(entity, Messages.Category.Added);
        }

        public Result<Category> Update(Category entity)
        {
            ecommerceContext.Categories.Update(entity);
            ecommerceContext.SaveChanges();

            return Result<Category>.Success(entity, Messages.Category.Updated);
        }

        public Result<bool> Delete(Category entity)
        {
            ecommerceContext.Categories.Remove(entity);
            ecommerceContext.SaveChanges();

            var result = GetById(entity.Id);

            return result is null ? Result<bool>.Success(true, Messages.Category.Deleted) : Result<bool>.Failure(Messages.Category.NotFound);
        }
    }
}
