using FreshThreads.Models;
using FreshThreads.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FreshThreads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        //Get : api/Delivery
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Delivery>>> GetDeliveries()
        {
            var deliveries = await _deliveryService.GetAllDeliveries();
            return Ok(deliveries);
        }

        //Get : api/Delivery/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Delivery>> GetDelivery(long id)
        {
            var delivery = await _deliveryService.GetDeliveryById(id);
            if (delivery == null)
            {
                return NotFound();
            }
            return Ok(delivery);
        }

        //Post : api/Delivery
        [HttpPost("create")]
        public async Task<ActionResult<Delivery>> CreateDelivery([FromBody] Delivery delivery)
        {
            var createdDelivery = await _deliveryService.CreateDelivery(delivery);
            return CreatedAtAction(nameof(GetDelivery), new { id = createdDelivery.DeliveryId }, createdDelivery);
        }

        //Put : api/Delivery/{id}
        [HttpPost("update")]
        public async Task<IActionResult> UpdateDelivery(long id, [FromBody] Delivery delivery)
        {
            if (id != delivery.DeliveryId)
            {
                return BadRequest("Delivery ID mismatch.");
            }
            var updatedDelivery = await _deliveryService.UpdateDelivery(id, delivery);
            if (updatedDelivery == null)
            {
                return NotFound();
            }
            return Ok(updatedDelivery);
        }

        //Delete : api/Delivery/{id}
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteDelivery(long id)
        {
            var result = await _deliveryService.DeleteDelivery(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
