namespace Ecommerce.API.Models
{        
    
    //Auditing Fields
        // Seperate Auditable Entities if it is necessary
    public abstract class Entity
    {
        public int Id { get; set; }


        public DateTime CreatedAt { get; set; }
       
        
        public DateTime? UpdatedAt { get; set; }


        public Entity()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
