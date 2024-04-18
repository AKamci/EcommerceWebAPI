namespace Ecommerce.API.Models
{
    public class Order:Entity
    {
        public DateTime OrderDate { get; set; }
        public User User { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
