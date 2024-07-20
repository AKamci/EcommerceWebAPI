namespace Ecommerce.API.Dtos;

public class CartDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public ICollection<CartItemDto> CartItems { get; set; }
}
