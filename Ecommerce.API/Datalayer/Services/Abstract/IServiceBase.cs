using Ecommerce.API.Infrastructure;

namespace Ecommerce.API.Datalayer.Services.Abstract
{
    public interface IServiceBase<T>
    {
        Result<T> GetById(int id);
        Result<List<T>> GetAll();
        Result<T> Add(T entity);
        Result<T> Update(T entity);
        Result<bool> Delete(int id);
    }
}
