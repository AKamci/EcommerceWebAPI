using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Repos.Abstract;
using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Datalayer.Services.Concrete;

public class ProductService : IProductService
{

    private readonly UnitOfWork _unitOfWork;

    public ProductService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Result<Product> GetById(int id)
    {
        var entity = _unitOfWork.ProductRepo.GetById(id);
        // Product To ProductDTO

        return entity is not null ? Result<Product>.Success(entity, Messages.Product.Found) : Result<Product>.Failure(Messages.Product.NotFound);
    }

    public Result<List<Product>> GetAll()
    {
        var entities = _unitOfWork.ProductRepo.GetAll();

        if (entities.Count > 0)
        {
            return Result<List<Product>>.Success(entities, Messages.Product.Found);
        }

        return Result<List<Product>>.Failure(Messages.Product.NotFound);
    }

    public Result<Product> Add(Product entity)
    {
        _unitOfWork.ProductRepo.Add(entity);
        _unitOfWork.SaveChanges();
        return Result<Product>.Success(entity, Messages.Product.Added);
    }

    public Result<Product> Update(Product entity)
    {
        _unitOfWork.ProductRepo.Update(entity);
        _unitOfWork.SaveChanges();
        return Result<Product>.Success(entity, Messages.Product.Updated);
    }

    public Result<bool> Delete(Product entity)
    {
        _unitOfWork.ProductRepo.Delete(entity.Id);

        var result = GetById(entity.Id);
        _unitOfWork.SaveChanges();
        return result is null ? Result<bool>.Success(true, Messages.Product.Deleted) : Result<bool>.Failure(Messages.Product.NotFound);
    }
}
