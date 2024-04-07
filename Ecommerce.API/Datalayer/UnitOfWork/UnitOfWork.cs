using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Repos.Abstract;
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
        await _context.SaveChangesAsync();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
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
