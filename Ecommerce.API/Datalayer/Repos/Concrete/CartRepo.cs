using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Repos.Abstract;
using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Datalayer.Repos.Concrete;

public class CartRepo : GenericRepo<Cart>, ICartRepo
{
    public CartRepo(EcommerceContext context) : base(context)
    {
    }

    public override List<Cart> GetAll()
    {
        return _context.Carts.Include(i => i.CartItems).ThenInclude(t => t.Product).ToList();

    }

    public IQueryable<Cart> GetAllQuery()
    {
        return _context.Carts
            .Include(i => i.CartItems)
            .ThenInclude(t => t.Product)
            .AsQueryable();
    }

}
