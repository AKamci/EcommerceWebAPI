using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Repos.Abstract;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Repos.Concrete;

public class OrderRepo : GenericRepo<Order>, IOrderRepo
{
    public OrderRepo(EcommerceContext context) : base(context)
    {
    }

    public int GetAmountOfDailyOrders()
    {
        return Where(t => t.OrderDate == DateTime.Today).Count();
    }
}
