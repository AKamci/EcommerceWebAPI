namespace Ecommerce.API.Models
{
    public class OrderItem:Entity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
