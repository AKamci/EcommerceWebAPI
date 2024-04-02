namespace Ecommerce.API.Models
{
    public class Cart:Entity
    {
        public User User { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
