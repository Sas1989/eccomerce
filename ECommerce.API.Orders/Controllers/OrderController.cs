using ECommerce.API.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Orders.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private IOrderProviders orderProvider;

        public OrderController(IOrderProviders orderProviders)
        {
            this.orderProvider = orderProviders;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetOrdersAsync(int customerId)
        {
            var result = await orderProvider.GetOrderAsync(customerId);
            if(result.IsSuccess)
            {
                return Ok(result.Orders);
            }

            return NotFound();
        }

    }
}
