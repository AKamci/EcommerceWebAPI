namespace Ecommerce.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        // Navigation Properties
        public Category Category { get; set; }
    }
}
