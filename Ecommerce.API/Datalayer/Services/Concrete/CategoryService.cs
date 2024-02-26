using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly EcommerceContext _ecommerceContext;

        public CategoryService(EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public Category GetById(int id)
        {
            return _ecommerceContext.Categories.Find(id);
        }

        public List<Category> GetAll()
        {
            return _ecommerceContext.Categories.ToList();
        }

        public void Add(Category entity)
        {
            _ecommerceContext.Categories.Add(entity);
            _ecommerceContext.SaveChanges();
        }

        public void Update(Category entity)
        {
            _ecommerceContext.Categories.Update(entity);
            _ecommerceContext.SaveChanges();
        }

        public void Delete(Category entity)
        {
            _ecommerceContext.Categories.Remove(entity);
            _ecommerceContext.SaveChanges();
        }
    }
}
