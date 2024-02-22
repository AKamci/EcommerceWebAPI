namespace Ecommerce.API.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        
        //Navigation properties
        public User User { get; set; }
        public List<Product> Products { get; set; }
    }
}
