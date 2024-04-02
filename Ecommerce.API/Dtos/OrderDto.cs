using Ecommerce.API.Models;

namespace Ecommerce.API.Dtos;

public class OrderDto
{
    public DateTime OrderDate { get; set; }
    public UserDto User { get; set; }
    public ICollection<OrderItemDto> OrderItems { get; set; }
}
