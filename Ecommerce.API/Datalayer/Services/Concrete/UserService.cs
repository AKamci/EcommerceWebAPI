using Ecommerce.API.Datalayer.Services.Abstract;
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

    public Result<User> GetById(int id)
    {
        var entity = _unitOfWork.UserRepo.GetById(id);
        
        // User To UserDTO
        return entity is not null ? Result<User>.Success(entity, Messages.User.Found) : Result<User>.Failure(Messages.User.NotFound);
    }

    public Result<List<User>> GetAll()
    {
        var entities = _unitOfWork.UserRepo.GetAll();

        if (entities.Count > 0)
        {
            return Result<List<User>>.Success(entities, Messages.User.Found);
        }

        return Result<List<User>>.Failure(Messages.User.NotFound);
    }

    public Result<User> Add(User entity)
    {
        _unitOfWork.UserRepo.Add(entity);
        _unitOfWork.SaveChanges();
        return Result<User>.Success(entity, Messages.User.Added);
    }

    public Result<User> Update(User entity)
    {
        _unitOfWork.UserRepo.Update(entity);
        _unitOfWork.SaveChanges();
        return Result<User>.Success(entity, Messages.User.Updated);
    }

    public Result<bool> Delete(int id)
    {
        _unitOfWork.UserRepo.Delete(id);

        var result = GetById(id);
        _unitOfWork.SaveChanges();
        return result is null ? Result<bool>.Success(true, Messages.User.Deleted) : Result<bool>.Failure(Messages.User.NotFound);
    }
}
