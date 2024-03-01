using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly EcommerceContext _ecommerceContext;

        public UserService(EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public Result<User> GetById(int id)
        {
            var entity = _ecommerceContext.Users.Find(id);

            return entity is not null ? Result<User>.Success(entity,"User found.") : Result<User>.Failure("User not found.");
        }

        public Result<List<User>> GetAll()
        {
            var entities = _ecommerceContext.Users.ToList();

            if (entities.Count > 0)
            {
                return Result<List<User>>.Success(entities, "Users found.");
            }

            return Result<List<User>>.Failure("Users not found.");
        }

        public Result<User> Add(User entity)
        {
            _ecommerceContext.Users.Add(entity);
            _ecommerceContext.SaveChanges();

            return Result<User>.Success(entity, "New User added.");
        }

        public Result<User> Update(User entity)
        {
            _ecommerceContext.Users.Update(entity);
            _ecommerceContext.SaveChanges();

            return Result<User>.Success(entity, "New User updated.");
        }

        public Result<bool> Delete(User entity)
        {
            _ecommerceContext.Users.Remove(entity);
            _ecommerceContext.SaveChanges();

            var result = GetById(entity.Id);

            return result is null ? Result<bool>.Success(true, "User is deleted.") : Result<bool>.Failure("User not found.");
        }
    }
}
