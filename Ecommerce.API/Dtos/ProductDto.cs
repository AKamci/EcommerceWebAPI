namespace Ecommerce.API.Dtos
{
    public class ProductDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }
}
