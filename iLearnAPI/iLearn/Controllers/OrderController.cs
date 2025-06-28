using Microsoft.AspNetCore.Mvc;
using OMS.DTO;

namespace OMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpGet("store/{storeId}")]
        public async Task<IActionResult> GetOrdersByStore([FromRoute] string storeId)
        {
            return Ok(new List<OrderResponse>());
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder([FromRoute] string orderId)
        {
            return Ok();
        }
    }
}
