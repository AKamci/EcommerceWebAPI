using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Repos.Abstract;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Repos.Concrete;

public class UserRepo : GenericRepo<User>, IUserRepo
{
    public UserRepo(EcommerceContext context) : base(context)
    {
    }
}
