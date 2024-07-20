using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Datalayer.Services.Mapping;
using Ecommerce.API.Dtos;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Datalayer.Services.Concrete;

public class CartService : ICartService
{
    private readonly UnitOfWork _unitOfWork;

    public CartService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Result<CartDto> GetById(int id)
    {
        var entity = _unitOfWork.CartRepo.GetById(id);

        // Cart To CartDTO
        var cartDto = ObjectMapper.Mapper.Map<CartDto>(entity);
        return entity is not null ? Result<CartDto>.Success(cartDto, Messages.Cart.Found) : Result<CartDto>.Failure(Messages.Cart.NotFound);
    }

    public Result<List<CartDto>> GetAll()
    {
        var entities = _unitOfWork.CartRepo.GetAll();

        if (entities.Count > 0)
        {
            var dtoList = ObjectMapper.Mapper.Map<List<CartDto>>(entities);
            return Result<List<CartDto>>.Success(dtoList, Messages.Cart.Found);
        }

        return Result<List<CartDto>>.Failure(Messages.Cart.NotFound);
    }

    public Result<CartDto> Add(CartDto entity)
    {
        var cart = ObjectMapper.Mapper.Map<Cart>(entity);
        _unitOfWork.CartRepo.Add(cart);
        _unitOfWork.SaveChanges();
        return Result<CartDto>.Success(entity, Messages.Cart.Added);
    }

    public Result<CartDto> Update(CartDto entity)
    {
        var cart = ObjectMapper.Mapper.Map<Cart>(entity);
        _unitOfWork.CartRepo.Update(cart);
        _unitOfWork.SaveChanges();
        return Result<CartDto>.Success(entity, Messages.Cart.Updated);
    }

    public Result<bool> Delete(int id)
    {
        _unitOfWork.CartRepo.Delete(id);

        var result = GetById(id);
        _unitOfWork.SaveChanges();
        return result is null ? Result<bool>.Success(true, Messages.Cart.Deleted) : Result<bool>.Failure(Messages.Cart.NotFound);
    }

    public Result<bool> AddSingleProduct(int customerId, int productId, int quantity)
    {
        var context = _unitOfWork._context;
        
        var cartDto = GetOrCreateCartForCurrentCustomer(customerId);
        var cart = ObjectMapper.Mapper.Map<Cart>(cartDto.Value);
        var cartEntry = context.Entry(cart);
        context.Entry(cart).State = EntityState.Unchanged;

        var cartInclude = _unitOfWork.CartRepo.GetAllQuery().AsNoTracking().ToList().FirstOrDefault(x => x.CustomerId == customerId);
        var cartItem = cartInclude.CartItems.FirstOrDefault(x => x.ProductId == productId);
       
        
        
        context.Entry(cartItem).State = EntityState.Unchanged;

        if (cartItem is not null)
        {
            cartItem.Quantity += quantity;
        }
        else
        {

            cart.CartItems.Add(new CartItem
            {
                Quantity = quantity,
                CartId = cart.Id,
                ProductId = productId
            });
            
        }       
        
        _unitOfWork.SaveChanges();

        return Result<bool>.Success(true, Messages.Cart.ProductAdded);
    }

    public Result<CartDto> CreateCartForCurrentCustomer(int customerId)
    {
        var cart = new Cart
        {
            CustomerId = customerId,
            CartItems = new List<CartItem>()
        };
        _unitOfWork.CartRepo.Add(cart);
        _unitOfWork.SaveChanges();
        var cartDto = ObjectMapper.Mapper.Map<CartDto>(cart);
        return Result<CartDto>.Success(cartDto);
    }

    public Result<CartDto> GetCartForCurrentCustomer(int customerId)
    {

        var cart = _unitOfWork.CartRepo.GetAllQuery().AsNoTracking()
            
            .SingleOrDefault(t => t.CustomerId == customerId);
        var cartDto = ObjectMapper.Mapper.Map<CartDto>(cart);
        return Result<CartDto>.Success(cartDto);
    }

    public Result<CartDto> GetOrCreateCartForCurrentCustomer(int customerId)
    {
        var cart = GetCartForCurrentCustomer(customerId).Value;
        if (cart is null)
        {
           cart = CreateCartForCurrentCustomer(customerId).Value;
        }

        return Result<CartDto>.Success(cart);
    }
}
