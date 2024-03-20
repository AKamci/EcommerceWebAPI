using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete
{
    public class UserService(EcommerceContext ecommerceContext) : IUserService
    {
        public Result<User> GetById(int id)
        {
            var entity = ecommerceContext.Users.Find(id);

            return entity is not null ? Result<User>.Success(entity, Messages.User.Found) : Result<User>.Failure(Messages.User.NotFound);
        }

        public Result<List<User>> GetAll()
        {
            var entities = ecommerceContext.Users.ToList();

            if (entities.Count > 0)
            {
                return Result<List<User>>.Success(entities, Messages.User.Found);
            }

            return Result<List<User>>.Failure(Messages.User.NotFound);
        }

        public Result<User> Add(User entity)
        {
            ecommerceContext.Users.Add(entity);
            ecommerceContext.SaveChanges();

            return Result<User>.Success(entity, Messages.User.Added);
        }

        public Result<User> Update(User entity)
        {
            ecommerceContext.Users.Update(entity);
            ecommerceContext.SaveChanges();

            return Result<User>.Success(entity, Messages.User.Updated);
        }

        public Result<bool> Delete(User entity)
        {
            ecommerceContext.Users.Remove(entity);
            ecommerceContext.SaveChanges();

            var result = GetById(entity.Id);

            return result is null ? Result<bool>.Success(true, Messages.User.Deleted) : Result<bool>.Failure(Messages.User.NotFound);
        }
    }
}
