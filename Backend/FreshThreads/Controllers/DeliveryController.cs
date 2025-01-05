using FreshThreads.DTO;
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

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<DeliveryDto>>> GetDeliveries()
        {
            var deliveries = await _deliveryService.GetAllDeliveries();
            return Ok(deliveries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryDto>> GetDelivery(long id)
        {
            var delivery = await _deliveryService.GetDeliveryById(id);
            if (delivery == null)
                return NotFound();
            return Ok(delivery);
        }

        [HttpPost("create")]
        public async Task<ActionResult<DeliveryDto>> CreateDelivery([FromBody] DeliveryDto deliveryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdDelivery = await _deliveryService.CreateDelivery(deliveryDto);
            return CreatedAtAction(nameof(GetDelivery), new { id = createdDelivery.DeliveryId }, createdDelivery);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateDelivery(long id, [FromBody] DeliveryDto deliveryDto)
        {
            if (!ModelState.IsValid || id != deliveryDto.DeliveryId)
            {
                return BadRequest("Invalid input data.");
            }

            var updatedDelivery = await _deliveryService.UpdateDelivery(id, deliveryDto);

            if (updatedDelivery == null)
            {
                return NotFound("Delivery not found.");
            }

            return Ok(updatedDelivery);
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteDelivery(long id)
        {
            var result = await _deliveryService.DeleteDelivery(id);
            if (!result)
                return NotFound();

            return Ok();
        }
    }
}

