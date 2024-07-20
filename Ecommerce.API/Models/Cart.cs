namespace Ecommerce.API.Models
{
    public class Cart:Entity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
