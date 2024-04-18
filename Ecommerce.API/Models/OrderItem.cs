namespace Ecommerce.API.Models
{
    public class OrderItem:Entity
    {
       
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; } 
        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}
