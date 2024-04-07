using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Repos.Abstract;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Repos.Concrete;

public class ProductRepo : GenericRepo<Product>, IProductRepo
{
    public ProductRepo(EcommerceContext context) : base(context)
    {
    }
}
