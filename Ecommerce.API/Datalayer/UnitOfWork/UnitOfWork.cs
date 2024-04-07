using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Repos.Abstract;
using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Datalayer;

public class UnitOfWork : IDisposable
{
    // Step 1: Reach out all the repositiries via UnitOfWork file.
    private ICartRepo _cartRepo;
    private ICategoryRepo _categoryRepo;
    private IOrderRepo _orderRepo;
    private IProductRepo _productRepo;
    private IUserRepo _userRepo;

    // Step 2: Add DbContext referance
    private readonly EcommerceContext _context;

    public UnitOfWork(ICartRepo cartRepo, ICategoryRepo categoryRepo, IOrderRepo orderRepo, IProductRepo productRepo, IUserRepo userRepo, EcommerceContext context)
    {
        _cartRepo = cartRepo;
        _categoryRepo = categoryRepo;
        _orderRepo = orderRepo;
        _productRepo = productRepo;
        _userRepo = userRepo;
        _context = context;
    }

    public ICartRepo CartRepo => _cartRepo;
    public ICategoryRepo CategoryRepo => _categoryRepo;
    public IOrderRepo OrderRepo => _orderRepo;
    public IProductRepo ProductRepo => _productRepo;
    public IUserRepo UserRepo => _userRepo;

    public async Task SaveChangesAsync()
    {
        UpdateAuditableFields();
        await _context.SaveChangesAsync();
    }

    public void SaveChanges()
    {
        UpdateAuditableFields();
        _context.SaveChanges();
    }

    private void UpdateAuditableFields()
    {
        var entries = _context.ChangeTracker.Entries<Entity>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }
            
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }

    public void Dispose()
    {
        _cartRepo = null;
        _categoryRepo = null;
        _orderRepo = null;
        _productRepo = null;
        _userRepo = null;
        _context.Dispose();
    }
}
