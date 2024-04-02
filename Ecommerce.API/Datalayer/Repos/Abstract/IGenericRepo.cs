using Ecommerce.API.Models;
using System.Linq.Expressions;

namespace Ecommerce.API.Datalayer.Repos.Abstract
{
    public interface IGenericRepo<TEntity> where TEntity:Entity
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity product);
        void Update(TEntity product);
        void Delete(int id);
    }
}
