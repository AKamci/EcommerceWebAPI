using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Infrastructure;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete
{
    public class CartService : ICartService
    {
        private readonly UnitOfWork _unitOfWork;

        public CartService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result<Cart> GetById(int id)
        {
            var entity = _unitOfWork.CartRepo.GetById(id);
            // Cart To CartDTO

        return entity is not null ? Result<Cart>.Success(entity, Messages.Cart.Found) : Result<Cart>.Failure(Messages.Cart.NotFound);
    }

        public Result<List<Cart>> GetAll()
        {
            var entities = _unitOfWork.CartRepo.GetAll();

        if (entities.Count > 0)
        {
            return Result<List<Cart>>.Success(entities, Messages.Cart.Found);
        }

        return Result<List<Cart>>.Failure(Messages.Cart.NotFound);
    }

        public Result<Cart> Add(Cart entity)
        {
            _unitOfWork.CartRepo.Add(entity);
            _unitOfWork.SaveChanges();
            return Result<Cart>.Success(entity, Messages.Cart.Added);
        }

        public Result<Cart> Update(Cart entity)
        {
            _unitOfWork.CartRepo.Update(entity);
            _unitOfWork.SaveChanges();
            return Result<Cart>.Success(entity, Messages.Cart.Updated);
        }

        public Result<bool> Delete(Cart entity)
        {
            _unitOfWork.CartRepo.Delete(entity.Id);

            var result = GetById(entity.Id);
            _unitOfWork.SaveChanges();
            return result is null ? Result<bool>.Success(true, Messages.Cart.Deleted) : Result<bool>.Failure(Messages.Cart.NotFound);
        }
    }
}
