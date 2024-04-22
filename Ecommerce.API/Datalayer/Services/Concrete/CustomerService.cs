using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Datalayer.Services.Mapping;
using Ecommerce.API.Dtos;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete;

public class CustomerService : ICustomerService
{

    private readonly UnitOfWork _unitOfWork;

    public CustomerService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Result<CustomerDto> GetById(int id)
    {
        var entity = _unitOfWork.UserRepo.GetById(id);

        // Customer To UserDTO
        var userDto = ObjectMapper.Mapper.Map<CustomerDto>(entity);
        return entity is not null ? Result<CustomerDto>.Success(userDto, Messages.User.Found) : Result<CustomerDto>.Failure(Messages.User.NotFound);
    }

    public Result<List<CustomerDto>> GetAll()
    {
        var entities = _unitOfWork.UserRepo.GetAll();

        if (entities.Count > 0)
        {
            var listDto = ObjectMapper.Mapper.Map<List<CustomerDto>>(entities);
            return Result<List<CustomerDto>>.Success(listDto, Messages.User.Found);
        }

        return Result<List<CustomerDto>>.Failure(Messages.User.NotFound);
    }

    public Result<CustomerDto> Add(CustomerDto dto)
    {
        var entity = ObjectMapper.Mapper.Map<Customer>(dto);
        _unitOfWork.UserRepo.Add(entity);
        _unitOfWork.SaveChanges();
        var lastDto = ObjectMapper.Mapper.Map<CustomerDto>(entity);
        return Result<CustomerDto>.Success(lastDto, Messages.User.Added);
    }

    public Result<CustomerDto> Update(CustomerDto dto)
    {
        var entity = ObjectMapper.Mapper.Map<Customer>(dto);

        _unitOfWork.UserRepo.Update(entity);
        _unitOfWork.SaveChanges();
        var lastDto = ObjectMapper.Mapper.Map<CustomerDto>(entity);

        return Result<CustomerDto>.Success(lastDto, Messages.User.Updated);
    }

    public Result<bool> Delete(int id)
    {
        _unitOfWork.UserRepo.Delete(id);

        var result = GetById(id);
        _unitOfWork.SaveChanges();
        return result is null ? Result<bool>.Success(true, Messages.User.Deleted) : Result<bool>.Failure(Messages.User.NotFound);
    }
}
