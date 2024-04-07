using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Repos.Abstract;
using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete;

public class UserService : IUserService
{

    private readonly IUserRepo _repo;

    public UserService(IUserRepo repo)
    {
        _repo = repo;
    }

    public Result<User> GetById(int id)
    {
        var entity = _repo.GetById(id);
        // Cart To CartDTO

        return entity is not null ? Result<User>.Success(entity, Messages.User.Found) : Result<User>.Failure(Messages.User.NotFound);
    }

    public Result<List<User>> GetAll()
    {
        var entities = _repo.GetAll();

        if (entities.Count > 0)
        {
            return Result<List<User>>.Success(entities, Messages.User.Found);
        }

        return Result<List<User>>.Failure(Messages.User.NotFound);
    }

    public Result<User> Add(User entity)
    {
        _repo.Add(entity);
        return Result<User>.Success(entity, Messages.User.Added);
    }

    public Result<User> Update(User entity)
    {
        _repo.Update(entity);

        return Result<User>.Success(entity, Messages.User.Updated);
    }

    public Result<bool> Delete(User entity)
    {
        _repo.Delete(entity.Id);

        var result = GetById(entity.Id);

        return result is null ? Result<bool>.Success(true, Messages.User.Deleted) : Result<bool>.Failure(Messages.User.NotFound);
    }
}
