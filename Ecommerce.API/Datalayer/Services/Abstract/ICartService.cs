using Ecommerce.API.Dtos;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Abstract
{
    public interface ICartService : IServiceBase<CartDto> {
        Result<bool> AddProduct(int customerId, int productId, int quantity);
        Result<Cart> CreateCartForCurrentCustomer(int customerId);
        Result<Cart> GetCartForCurrentCustomer(int customerId);
        Result<Cart> GetOrCreateCartForCurrentCustomer(int customerId);
        Result<bool> RemoveProduct(int customerId, int productId);
        Result<bool> UpdateProduct(int customerId, int productId, int quantity);
    };
}
