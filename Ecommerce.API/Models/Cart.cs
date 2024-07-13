namespace Ecommerce.API.Models
{
    public class Cart:Entity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
