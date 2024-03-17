using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        // [NotMapped]
        public Category Category { get; set; }
    }
}
