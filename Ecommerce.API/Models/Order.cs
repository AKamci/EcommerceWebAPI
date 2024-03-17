namespace Ecommerce.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
