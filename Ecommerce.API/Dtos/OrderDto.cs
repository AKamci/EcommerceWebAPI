using Ecommerce.API.Models;

namespace Ecommerce.API.Dtos;

public class OrderDto
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public CustomerDto User { get; set; }
    public ICollection<OrderItemDto> OrderItems { get; set; }
}
