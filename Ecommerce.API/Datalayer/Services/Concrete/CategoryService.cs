using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly EcommerceContext _ecommerceContext;

        public CategoryService(EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public Result<Category> GetById(int id)
        {
            var entity = _ecommerceContext.Categories.Find(id);

            return entity is not null ? Result<Category>.Success(entity,"Category found.") : Result<Category>.Failure("Category not found.");
        }

        public Result<List<Category>> GetAll()
        {
            var entities = _ecommerceContext.Categories.ToList();

            if (entities.Count > 0)
            {
                return Result<List<Category>>.Success(entities, "Categories found.");
            }

            return Result<List<Category>>.Failure("Categories not found.");
        }

        public Result<Category> Add(Category entity)
        {
            _ecommerceContext.Categories.Add(entity);
            _ecommerceContext.SaveChanges();

            return Result<Category>.Success(entity, "New Category added.");
        }

        public Result<Category> Update(Category entity)
        {
            _ecommerceContext.Categories.Update(entity);
            _ecommerceContext.SaveChanges();

            return Result<Category>.Success(entity, "New Category updated.");
        }

        public Result<bool> Delete(Category entity)
        {
            _ecommerceContext.Categories.Remove(entity);
            _ecommerceContext.SaveChanges();

            var result = GetById(entity.Id);

            return result is null ? Result<bool>.Success(true, "Category is deleted.") : Result<bool>.Failure("Category not found.");
        }
    }
}
