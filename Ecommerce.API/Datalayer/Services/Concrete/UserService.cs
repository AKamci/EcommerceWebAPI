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

            return entity is not null ? Result<User>.Success(entity,"User found.") : Result<User>.Failure("User not found.");
        }

        public Result<List<User>> GetAll()
        {
            var entities = ecommerceContext.Users.ToList();

            if (entities.Count > 0)
            {
                return Result<List<User>>.Success(entities, "Users found.");
            }

            return Result<List<User>>.Failure("Users not found.");
        }

        public Result<User> Add(User entity)
        {
            ecommerceContext.Users.Add(entity);
            ecommerceContext.SaveChanges();

            return Result<User>.Success(entity, "New User added.");
        }

        public Result<User> Update(User entity)
        {
            ecommerceContext.Users.Update(entity);
            ecommerceContext.SaveChanges();

            return Result<User>.Success(entity, "New User updated.");
        }

        public Result<bool> Delete(User entity)
        {
            ecommerceContext.Users.Remove(entity);
            ecommerceContext.SaveChanges();

            var result = GetById(entity.Id);

            return result is null ? Result<bool>.Success(true, "User is deleted.") : Result<bool>.Failure("User not found.");
        }
    }
}
