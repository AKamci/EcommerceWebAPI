using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Repos.Abstract
{
    public interface IOrderRepo : IGenericRepo<Order>
    {
        int GetAmountOfDailyOrders();
    }
}
