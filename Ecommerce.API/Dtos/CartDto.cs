namespace Ecommerce.API.Dtos;

public class CartDto
{
    public UserDto User { get; set; }
    public ICollection<CartItemDto> CartItems { get; set; }
}
