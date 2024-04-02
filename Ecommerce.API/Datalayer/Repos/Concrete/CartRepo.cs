using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Repos.Abstract;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Repos.Concrete;

public class CartRepo : GenericRepo<Cart>, ICartRepo
{
    public CartRepo(EcommerceContext context) : base(context)
    {
    }
}
