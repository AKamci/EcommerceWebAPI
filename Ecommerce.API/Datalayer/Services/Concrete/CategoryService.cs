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

            return entity is not null ? Result<Category>.Success(entity,"Category found.") : Result<Category>.Failure("Category not found.");
        }

        public Result<List<Category>> GetAll()
        {
            var entities = ecommerceContext.Categories.ToList();

            if (entities.Count > 0)
            {
                return Result<List<Category>>.Success(entities, "Categories found.");
            }

            return Result<List<Category>>.Failure("Categories not found.");
        }

        public Result<Category> Add(Category entity)
        {
            ecommerceContext.Categories.Add(entity);
            ecommerceContext.SaveChanges();

            return Result<Category>.Success(entity, "New Category added.");
        }

        public Result<Category> Update(Category entity)
        {
            ecommerceContext.Categories.Update(entity);
            ecommerceContext.SaveChanges();

            return Result<Category>.Success(entity, "New Category updated.");
        }

        public Result<bool> Delete(Category entity)
        {
            ecommerceContext.Categories.Remove(entity);
            ecommerceContext.SaveChanges();

            var result = GetById(entity.Id);

            return result is null ? Result<bool>.Success(true, "Category is deleted.") : Result<bool>.Failure("Category not found.");
        }
    }
}
