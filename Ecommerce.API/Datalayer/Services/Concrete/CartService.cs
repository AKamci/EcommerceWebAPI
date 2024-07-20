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

    public Result<bool> AddProduct(int customerId, int productId, int quantity)
    {        
        var cart = GetOrCreateCartForCurrentCustomer(customerId);
        var product = cart.Value.CartItems.FirstOrDefault(x => x.ProductId == productId);
        if (product is null) {
            cart.Value.CartItems.Add(new CartItem
            {
                ProductId = productId,
                Quantity = quantity,
                CartId = cart.Value.Id
            });
        } else
        {
            product.Quantity += quantity;
        }
               
        
        _unitOfWork.SaveChanges();

        return Result<bool>.Success(true, Messages.Cart.ProductAdded);
    }

    public Result<Cart> CreateCartForCurrentCustomer(int customerId)
    {
        var cart = new Cart
        {
            CustomerId = customerId,
            CartItems = new List<CartItem>()
        };
        _unitOfWork.CartRepo.Add(cart);
        _unitOfWork.SaveChanges();
        return Result<Cart>.Success(cart);
    }

    public Result<Cart> GetCartForCurrentCustomer(int customerId)
    {

        var cart = _unitOfWork.CartRepo.GetAll().SingleOrDefault(t => t.CustomerId == customerId);
        return Result<Cart>.Success(cart);
    }

    public Result<Cart> GetOrCreateCartForCurrentCustomer(int customerId)
    {
        var cart = GetCartForCurrentCustomer(customerId).Value;
        if (cart is null)
        {
           cart = CreateCartForCurrentCustomer(customerId).Value;
        }

        return Result<Cart>.Success(cart);
    }

    public Result<bool> RemoveProduct(int customerId, int productId)
    {
        var cart = GetOrCreateCartForCurrentCustomer(customerId);
        var product = cart.Value.CartItems.FirstOrDefault(x => x.ProductId == productId);
        if (product is not null)
        {
            cart.Value.CartItems.Remove(product);
        }

        _unitOfWork.SaveChanges();

        return Result<bool>.Success(true, Messages.Cart.ProductRemoved);
    }

    public Result<bool> UpdateProduct(int customerId, int productId, int quantity)
    {
        var cart = GetOrCreateCartForCurrentCustomer(customerId);
        var product = cart.Value.CartItems.FirstOrDefault(x => x.ProductId == productId);
        if (product is not null) {
            product.Quantity = quantity;
        }

        _unitOfWork.SaveChanges();

        return Result<bool>.Success(true, Messages.Cart.ProductRemoved);
    }
}
