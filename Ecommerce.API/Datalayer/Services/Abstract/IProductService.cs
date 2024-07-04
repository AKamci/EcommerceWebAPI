using Ecommerce.API.Dtos;
using Ecommerce.API.Infrastructure;

namespace Ecommerce.API.Datalayer.Services.Abstract
{
    public interface IProductService : IServiceBase<ProductDto> {
        Result<List<ProductDto>> GetAllByCategoryId(int categoryId);
    }
}
