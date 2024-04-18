using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Datalayer.Services.Mapping;
using Ecommerce.API.Dtos;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

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
}
