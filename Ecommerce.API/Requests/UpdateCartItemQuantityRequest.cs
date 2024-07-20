namespace Ecommerce.API.Requests
{
    public class UpdateCartItemQuantityRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
