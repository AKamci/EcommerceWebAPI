using Ecommerce.API.Datalayer.Context;
using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Datalayer.Services.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Sql Server Connection Settings
            builder.Services.AddDbContext<EcommerceContext>(options =>
            {
                //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
                options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnectionString"));
            });

            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();

            // Add custom services
            // Dependency Injection(DI) Container
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<ICartService, CartService>();
            builder.Services.AddTransient<ICategoryService, CategoryService>();
            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddTransient<IOrderService, OrderService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
