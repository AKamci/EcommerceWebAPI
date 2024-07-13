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
    public IActionResult AddSingleProduct(AddToCartRequest request)
    {
        var result = cartService.AddSingleProduct(22, request.ProductId, request.Quantity);
        return Ok(result);
    }
}