namespace Ecommerce.API.Models
{
    public class Order:Entity
    {
        
        public DateTime OrderDate { get; set; }
        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
