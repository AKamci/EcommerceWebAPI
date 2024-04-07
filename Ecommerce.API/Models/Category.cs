namespace Ecommerce.API.Models
{
    public class Category:Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public ICollection<User> Products { get; set; }
    }
}
