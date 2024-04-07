using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete;

public class CategoryService(UnitOfWork unitOfWork) : ICategoryService
    {
        public Result<Category> GetById(int id)
        {
            var entity = unitOfWork.CategoryRepo.GetById(id);

        return entity is not null ? Result<Category>.Success(entity, Messages.Cart.Found) : Result<Category>.Failure(Messages.Cart.NotFound);
    }

        public Result<List<Category>> GetAll()
        {
            var entities = unitOfWork.CategoryRepo.GetAll();

        if (entities.Count > 0)
        {
            return Result<List<Category>>.Success(entities, Messages.Category.Found);
        }

        return Result<List<Category>>.Failure(Messages.Category.NotFound);
    }

        public Result<Category> Add(Category entity)
        {
            unitOfWork.CategoryRepo.Add(entity);
            unitOfWork.SaveChanges();

            return Result<Category>.Success(entity, Messages.Category.Added);
        }

        public Result<Category> Update(Category entity)
        {
            unitOfWork.CategoryRepo.Update(entity);
            unitOfWork.SaveChanges();

        return Result<Category>.Success(entity, Messages.Category.Updated);
    }

        public Result<bool> Delete(Category entity)
        {
            unitOfWork.CategoryRepo.Delete(entity.Id);
            unitOfWork.SaveChanges();

        var result = GetById(entity.Id);

        return result is null ? Result<bool>.Success(true, Messages.Category.Deleted) : Result<bool>.Failure(Messages.Category.NotFound);
    }
}
