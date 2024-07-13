using Ecommerce.API.Dtos;
using Ecommerce.API.Infrastructure;

namespace Ecommerce.API.Datalayer.Services.Abstract
{
    public interface ICartService : IServiceBase<CartDto> {
        Result<bool> AddSingleProduct(int customerId, int productId, int amount);
        Result<CartDto> CreateCartForCurrentCustomer(int customerId);
        Result<CartDto> GetCartForCurrentCustomer(int customerId);
        Result<CartDto> GetOrCreateCartForCurrentCustomer(int customerId);
    };
}
