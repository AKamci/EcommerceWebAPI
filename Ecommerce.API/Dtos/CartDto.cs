namespace Ecommerce.API.Dtos;

public class CartDto
{
    public int Id { get; set; }
    public CustomerDto User { get; set; }
    public ICollection<CartItemDto> CartItems { get; set; }
}
