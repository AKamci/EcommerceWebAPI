namespace Ecommerce.API.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int Price { get; set; }

        public User User { get; set; }

    }
}
