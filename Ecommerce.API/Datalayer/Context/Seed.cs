using Ecommerce.API.Models;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

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
            var OrderList = new List<Order>();


            var user = new User() { Id = 40, Age = 88, Email = "Deneme", Name = "Ali", Surname = "Veli" };
            var order = new Order() { Id = 102, OrderDate = DateTime.Now, User = user };
            order.OrderItems.Add(new() { Id = 1, Quantity = 100, OrderId= order.Id});

            var user2 = new User() { Id = 42, Age = 88, Email = "Deneme", Name = "Ali", Surname = "Veli" };
            var order2 = new Order() { Id = 101, OrderDate = DateTime.Now, User = user2 };
            order2.OrderItems.Add(new() { Id = 1, Quantity = 100, OrderId = order.Id });

            var user3 = new User() { Id = 44, Age = 88, Email = "Deneme", Name = "Ali", Surname = "Veli" };
            var order3 = new Order() { Id = 100, OrderDate = DateTime.Now, User = user3 };
            order3.OrderItems.Add(new() { Id = 1, Quantity = 100, OrderId = order.Id });

            OrderList.Add(order);
            OrderList.Add(order2);
            OrderList.Add(order3);

            return OrderList;
            
        }

        public static List<User> ReadUserFromJsonFile()
        {
            string jsonString = File.ReadAllText(Path.Combine("Datalayer","Context","data.json"));
            List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonString);
            return users;
        }

    }
}