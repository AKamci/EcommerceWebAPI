namespace Ecommerce.API.Models
{
    public class IdCard
    {
        public int Id { get; set; }
        public int UserId { get; set; }



        // Navigation Properties
        public User User { get; set; }
    }
}
