using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers.User;

//[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class CartsController(ICartService cartService) : ControllerBase
{
    [HttpPost]
    public IActionResult GetCartOfCustomer(int customerId)
    {
        var result = cartService.GetOrCreateCartForCurrentCustomer(customerId);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddProduct(AddToCartRequest request)
    {
        var result = cartService.AddProduct(22, request.ProductId, request.Quantity);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult UpdateCartItemQuantity(UpdateCartItemQuantityRequest request)
    {
        var result = cartService.UpdateProduct(22, request.ProductId, request.Quantity);
        return Ok(result);
    }

    [HttpDelete("{productId}")]
    public IActionResult RemoveProduct(int productId)
    {
        var result = cartService.RemoveProduct(22, productId);
        return Ok(result);
    }
}