using Ecommerce.API.Datalayer.Services.Abstract;
using Ecommerce.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
        public class OrdersController(IOrderService orderService) : ControllerBase
        {
            [HttpGet]
            [Route("{id:int}")]
            public IActionResult GetById(int id)
            {
                var result = orderService.GetById(id);
                return result.IsSuccess ? Ok(result) : NotFound();
            }

            [HttpGet]
            public IActionResult GetAll()
            {
                var result = orderService.GetAll();
                return Ok(result);
            }

            [HttpPost]
            public IActionResult Add(OrderDto order)
            {
                var result = orderService.Add(order);
                return Ok(result);
            }

            [HttpPut]
            public IActionResult Update(OrderDto order)
            {
                var result = orderService.Update(order);
                return Ok(result);
            }

            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var entity = orderService.GetById(id);
                var result = orderService.Delete(entity.Value.Id);
                return result.IsSuccess ? Ok(result) : NotFound();
            }
        }

    }
