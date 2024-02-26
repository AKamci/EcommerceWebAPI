using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Abstract
{
    public interface ICartService : IServiceBase<Cart>
    {
        void SpecificMethodForCart();
    };
}
