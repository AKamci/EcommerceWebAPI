namespace Ecommerce.API.Models
{
    public class Order:Entity
    {
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
