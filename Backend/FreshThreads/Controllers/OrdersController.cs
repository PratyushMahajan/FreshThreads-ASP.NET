using Microsoft.AspNetCore.Mvc;
using FreshThreads.Models;
using FreshThreads.Services; 
using System.Collections.Generic;
using System.Threading.Tasks;
using FreshThreads.Services.Interface;

namespace FreshThreads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService; // Inject OrdersService

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            var orders = await _ordersService.GetAllOrders();
            return Ok(orders);
        }

        // GET: api/Orders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrder(long id)
        {
            var order = await _ordersService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Orders>> CreateOrder([FromBody] Orders order)
        {
            var createdOrder = await _ordersService.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.OrdersId }, createdOrder);
        }

        // PUT: api/Orders/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(long id, [FromBody] Orders order)
        {
            if (id != order.OrdersId)
            {
                return BadRequest("Order ID mismatch.");
            }

            var updatedOrder = await _ordersService.UpdateOrder(order);
            if (updatedOrder == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/Orders/{id}
        [HttpDelete("{id}")]
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
