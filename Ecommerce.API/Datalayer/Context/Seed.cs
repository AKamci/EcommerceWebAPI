using Ecommerce.API.Models;
using Newtonsoft.Json;
using System;

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

        public static List<Product> Products()
        {
            return new List<Product> {
                new Product{
                    Id = 1,
                    CategoryId = 2,
                    Name = "Book",
                    Description = "LOTR Series",
                    Price = 1000,                   
                },
                new Product{
                    Id = 2,
                    CategoryId = 1,
                    Name = "Iphone 15  256GB",
                    Description = "Iphone 15 Blue Color",
                    Price = 90000,
                },
                new Product{
                    Id = 3,
                    CategoryId = 3,
                    Name = "SpiderMan Action Figure",
                    Description = "Marvel licensed spiderman product",
                    Price = 6500,
                },
            };
        }

        public static List<User> Users()
        {
            return new List<User>
            {
                new User
                {
                    Id = 11,
                    Name = "Ali",
                    Surname = "Veli",
                    Email = "aliveli@gmail.com",
                    Age = 55
                },
                new User
                {
                    Id = 22,
                    Name = "Mehmet",
                    MiddleName = "Tan",
                    Surname = "San",
                    Email = "mehmet@gmail.com",
                    Age = 20
                },
                new User
                {
                    Id = 33,
                    Name = "Serpil",
                    Surname = "Kuş",
                    Email = "serpkus@gmail.com",
                    Age = 45
                },
            };

        }

        public static List<Order> Orders()
        {
            return new List<Order>
            {
                new Order
                {
                    Id= 1,
                    OrderDate = DateTime.Now,
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            Id = 1,
                            OrderId = 1,
                            Quantity = 10,
                            ProductId = 1,
                        }
                    },
                    User = new User
                    {
                        Id = 22,
                        Name = "Mehmet",
                        MiddleName = "Tan",
                        Surname = "San",
                        Email = "mehmet@gmail.com",
                        Age = 20
                    }                  
                },
                new Order
                {
                    Id= 5,
                    OrderDate = DateTime.Now,
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            Id = 6,
                            OrderId = 2,
                            Quantity = 150,
                            ProductId = 13,
                        }
                    },
                    User = new User
                    {
                        Id = 22,
                        Name = "Mehmet",
                        MiddleName = "Tan",
                        Surname = "San",
                        Email = "mehmet@gmail.com",
                        Age = 20
                    }
                }
            };
        }



        public static List<User> JsonFileRead()
        {
            string jsonString = File.ReadAllText("C:\\Users\\abdul\\OneDrive\\Desktop\\Github Dosyaları\\EcommerceWebAPI\\data.json");
            List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonString);
            return users;
        }

       

        





        // Product Seed

        // User Seed

        // 2. adımda json dosyasından veri okuyarak seed işlemi yap.
    }
}
