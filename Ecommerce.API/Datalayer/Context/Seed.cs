using Ecommerce.API.Models;

namespace Ecommerce.API.Datalayer.Context
{
    public class Seed
    {
        public static List<Category> Categories()
        {
            return new List<Category> {
                new Category{
                    Id = 1,
                    Name = "Electronic",
                    Description = "Electronic products.",
                    IsActive = true
                },
                new Category{
                    Id = 2,
                    Name = "Books",
                    Description = "Books products.",
                    IsActive = true
                },
                new Category{
                    Id = 3,
                    Name = "Toys",
                    Description = "Toys products.",
                    IsActive = true
                },
            };
        }

        // Product Seed

        // User Seed

        // 2. adımda json dosyasından veri okuyarak seed işlemi yap.
    }
}
