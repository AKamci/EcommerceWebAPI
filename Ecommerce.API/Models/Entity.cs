namespace Ecommerce.API.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }

        //Auditing Fields
        // Seperate Auditable Entities if it is necessary
        public DateTime CreatedAt { get; set; }
       
        //public int CreatedBy { get; set; }
        
        public DateTime? UpdatedAt { get; set; }
        
        //public int UpdatedBy { get; set; }
    }
}
