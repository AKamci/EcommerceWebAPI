namespace Ecommerce.API.Models
{
    public class CartItem:Entity
    {

        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
