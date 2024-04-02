using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Repos.Abstract;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Repos.Concrete;

public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
{
    public CategoryRepo(EcommerceContext context) : base(context)
    {
    }
}
