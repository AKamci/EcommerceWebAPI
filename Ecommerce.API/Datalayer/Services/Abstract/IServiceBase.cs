namespace Ecommerce.API.Datalayer.Services.Abstract
{
    public interface IServiceBase<T>
    {
        T GetById(int id);
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
