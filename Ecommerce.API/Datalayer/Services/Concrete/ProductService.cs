using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Datalayer.Services.Mapping;
using Ecommerce.API.Dtos;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete;

public class ProductService : IProductService
{

    private readonly UnitOfWork _unitOfWork;

    public ProductService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Result<ProductDto> GetById(int id)
    {
        var entity = _unitOfWork.ProductRepo.GetById(id);
        // Product To ProductDTO
        var productDto = ObjectMapper.Mapper.Map<ProductDto>(entity);
        return entity is not null ? Result<ProductDto>.Success(productDto, Messages.Product.Found) : Result<ProductDto>.Failure(Messages.Product.NotFound);
    }

    public Result<List<ProductDto>> GetAll()
    {
        var entities = _unitOfWork.ProductRepo.GetAll();

        if (entities.Count > 0)
        {
            var listDto = ObjectMapper.Mapper.Map<List<ProductDto>>(entities);
            return Result<List<ProductDto>>.Success(listDto, Messages.Product.Found);
        }

        return Result<List<ProductDto>>.Failure(Messages.Product.NotFound);
    }

    public Result<ProductDto> Add(ProductDto dto)
    {
        var entity = ObjectMapper.Mapper.Map<Product>(dto);
        _unitOfWork.ProductRepo.Add(entity);
        _unitOfWork.SaveChanges();

        var lastDto = ObjectMapper.Mapper.Map<ProductDto>(entity);
        return Result<ProductDto>.Success(lastDto, Messages.Product.Added);
    }

    public Result<ProductDto> Update(ProductDto dto)
    {
        var entity = ObjectMapper.Mapper.Map<Product>(dto);
        _unitOfWork.ProductRepo.Update(entity);
        _unitOfWork.SaveChanges();

        var lastDto = ObjectMapper.Mapper.Map<ProductDto>(entity);
        return Result<ProductDto>.Success(lastDto, Messages.Product.Updated);
    }

    public Result<bool> Delete(int id)
    {
        _unitOfWork.ProductRepo.Delete(id);

        var result = GetById(id);
        _unitOfWork.SaveChanges();
        return result is null ? Result<bool>.Success(true, Messages.Product.Deleted) : Result<bool>.Failure(Messages.Product.NotFound);
    }
}
