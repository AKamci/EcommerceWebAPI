using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Repos.Abstract;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Repos.Concrete;

public class CustomerRepo : GenericRepo<Customer>, ICustomerRepo
{
    public CustomerRepo(EcommerceContext context) : base(context)
    {
    }
}
