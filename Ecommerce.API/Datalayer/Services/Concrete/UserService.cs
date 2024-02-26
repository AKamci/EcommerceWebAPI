using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Services.Abstract;
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

        public User GetById(int id)
        {
            return _ecommerceContext.Users.Find(id);
        }

        public List<User> GetAll()
        {
            return _ecommerceContext.Users.ToList();
        }

        public void Add(User entity)
        {
            _ecommerceContext.Users.Add(entity);
            _ecommerceContext.SaveChanges();
        }

        public void Update(User entity)
        {
            _ecommerceContext.Users.Update(entity);
            _ecommerceContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            _ecommerceContext.Users.Remove(entity);
            _ecommerceContext.SaveChanges();
        }
    }
}
