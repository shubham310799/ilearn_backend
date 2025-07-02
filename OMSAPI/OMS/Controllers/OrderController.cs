using Microsoft.AspNetCore.Mvc;
using OMS.Common;
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
            return Ok(new OrdersSummaryResponse
            {
                Orders = new List<OrderResponse>
                {
                    new OrderResponse
                    {
                        OrderId = 1234,
                        OrderCreateDt = DateTime.Now,
                        OrderStatus = OrderStatus.Created
                    },
                    new OrderResponse
                    {
                        OrderId = 1234,
                        OrderCreateDt = DateTime.Now,
                        OrderStatus = OrderStatus.Created
                    },
                    new OrderResponse
                    {
                        OrderId = 1234,
                        OrderCreateDt = DateTime.Now,
                        OrderStatus = OrderStatus.Created
                    },
                    new OrderResponse
                    {
                        OrderId = 1234,
                        OrderCreateDt = DateTime.Now,
                        OrderStatus = OrderStatus.Created
                    },
                    new OrderResponse
                    {
                        OrderId = 1234,
                        OrderCreateDt = DateTime.Now,
                        OrderStatus = OrderStatus.Created
                    },
                    new OrderResponse
                    {
                        OrderId = 1234,
                        OrderCreateDt = DateTime.Now,
                        OrderStatus = OrderStatus.Created
                    },
                    new OrderResponse
                    {
                        OrderId = 1234,
                        OrderCreateDt = DateTime.Now,
                        OrderStatus = OrderStatus.Created
                    },
                    new OrderResponse
                    {
                        OrderId = 1234,
                        OrderCreateDt = DateTime.Now,
                        OrderStatus = OrderStatus.Created
                    },
                    new OrderResponse
                    {
                        OrderId = 1234,
                        OrderCreateDt = DateTime.Now,
                        OrderStatus = OrderStatus.Created
                    }
                }
            });
        }

        [HttpGet("summary/{orderId}")]
        public async Task<IActionResult> GetOrderSummary([FromRoute] int orderId)
        {
            return Ok(new OrderResponse
            {
                OrderId = orderId,
                OrderCreateDt = DateTime.Now,
                OrderStatus = OrderStatus.Processing
            });
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder([FromRoute] string orderId)
        {
            return Ok(new OrderDetailsResponse
            {

            });
        }
    }
}
