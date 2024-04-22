using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Datalayer.Services.Mapping;
using Ecommerce.API.Dtos;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete;

public class UserService : IUserService
{

    private readonly UnitOfWork _unitOfWork;

    public UserService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Result<UserDto> GetById(int id)
    {
        var entity = _unitOfWork.UserRepo.GetById(id);

        // User To UserDTO
        var userDto = ObjectMapper.Mapper.Map<UserDto>(entity);
        return entity is not null ? Result<UserDto>.Success(userDto, Messages.User.Found) : Result<UserDto>.Failure(Messages.User.NotFound);
    }

    public Result<List<UserDto>> GetAll()
    {
        var entities = _unitOfWork.UserRepo.GetAll();

        if (entities.Count > 0)
        {
            var listDto = ObjectMapper.Mapper.Map<List<UserDto>>(entities);
            return Result<List<UserDto>>.Success(listDto, Messages.User.Found);
        }

        return Result<List<UserDto>>.Failure(Messages.User.NotFound);
    }

    public Result<UserDto> Add(UserDto dto)
    {
        var entity = ObjectMapper.Mapper.Map<User>(dto);
        _unitOfWork.UserRepo.Add(entity);
        _unitOfWork.SaveChanges();
        var lastDto = ObjectMapper.Mapper.Map<UserDto>(entity);
        return Result<UserDto>.Success(lastDto, Messages.User.Added);
    }

    public Result<UserDto> Update(UserDto dto)
    {
        var entity = ObjectMapper.Mapper.Map<User>(dto);

        _unitOfWork.UserRepo.Update(entity);
        _unitOfWork.SaveChanges();
        var lastDto = ObjectMapper.Mapper.Map<UserDto>(entity);

        return Result<UserDto>.Success(lastDto, Messages.User.Updated);
    }

    public Result<bool> Delete(int id)
    {
        _unitOfWork.UserRepo.Delete(id);

        var result = GetById(id);
        _unitOfWork.SaveChanges();
        return result is null ? Result<bool>.Success(true, Messages.User.Deleted) : Result<bool>.Failure(Messages.User.NotFound);
    }
}
