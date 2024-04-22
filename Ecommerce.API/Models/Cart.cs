namespace Ecommerce.API.Models
{
    public class Cart:Entity
    {
        public Customer Customer { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
