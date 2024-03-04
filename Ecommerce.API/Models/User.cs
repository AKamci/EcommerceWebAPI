using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Models
{
    public class User
    {
        public int Id { get; set; }
        [MinLength(3)]
        public string Name { get; set; } // Min: 3 chars Max: 97
        [MinLength(3)]

        public string Surname { get; set; } // Min: 3 chars Max: 9
        [MinLength(3)]
        public string? MiddleName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; } // min:18 max:70
    }
}
