using FreshThreads.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FreshThreads.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemsService _service;

        public OrderItemsController(IOrderItemsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderItems()
        {
            var orderItems = await _service.GetOrderItems();
            return Ok(orderItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItemById(long id)
        {
            var orderItem = await _service.GetOrderItemById(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            return Ok(orderItem);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderItem([FromBody] OrderItemsDto orderItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.AddOrderItem(orderItemDto);
            return CreatedAtAction(nameof(GetOrderItemById), new { id = orderItemDto.OrderItemId }, orderItemDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderItem(long id, [FromBody] OrderItemsDto orderItemDto)
        {
            if (id != orderItemDto.OrderItemId || !ModelState.IsValid)
            {
                return BadRequest();
            }
            await _service.UpdateOrderItem(orderItemDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(long id)
        {
            await _service.DeleteOrderItem(id);
            return NoContent();
        }
    }

}
