using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FreshThreads.Models;
using FreshThreads.Services.Interface;
using FreshThreads.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreshThreads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        // GET: api/Orders
        [HttpGet]
        [Authorize(Policy = "RequireShopOwnerRole")]
        public async Task<ActionResult<IEnumerable<OrdersDto>>> GetAllOrders()
        {
            var orders = await _ordersService.GetAllOrders();
            return Ok(orders);
        }

        // GET: api/Orders/{id}
        [HttpGet("{id}")]
        [Authorize(Policy = "RequireAdminRole, RequireShopOwnerRole, RequireDeliveryPartnerRole, RequireUserRole")]
        public async Task<ActionResult<OrdersDto>> GetOrderById(long id)
        {
            var order = await _ordersService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST: api/Orders (Only Users can create orders)
        [HttpPost]
        [Authorize(Policy = "RequireUserRole")]
        public async Task<ActionResult<OrdersDto>> CreateOrder([FromBody] OrderRequestDto orderDto)
        {
            var createdOrder = await _ordersService.CreateOrder(orderDto);
            return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.OrdersId }, createdOrder);
        }

        // PUT: api/Orders/{id}
        [HttpPut("{id}")]
        [Authorize(Policy = "RequireAdminRole, RequireShopOwnerRole")]
        public async Task<IActionResult> UpdateOrder(long id, [FromBody] OrderRequestDto orderDto)
        {
            var updatedOrder = await _ordersService.UpdateOrder(id, orderDto);
            if (updatedOrder == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/Orders/{id} (Only Admins can delete orders)
        [HttpDelete("{id}")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> DeleteOrder(long id)
        {
            var deleted = await _ordersService.DeleteOrder(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
