namespace Ecommerce.API.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
