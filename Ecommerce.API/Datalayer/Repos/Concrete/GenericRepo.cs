using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Repos.Abstract;
using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.API.Datalayer.Repos.Concrete;

public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity: Entity
{
    protected readonly EcommerceContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepo(EcommerceContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public virtual TEntity Add(TEntity product)
    {
        _dbSet.Add(product);
        return product;
    }

    public virtual void Delete(int id)
    {
        var entity = GetById(id);
        if(entity != null)
        {
            _dbSet.Remove(entity);
        }
    }

    public virtual List<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }

    public TEntity GetById(int id)
    {
        var entity = _dbSet.Find(id);
        if (entity is null)
        {
            return null;
        }

        return entity;
    }

    public virtual void Update(TEntity product)
    {
        _dbSet.Update(product);
    }

    public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }
}
