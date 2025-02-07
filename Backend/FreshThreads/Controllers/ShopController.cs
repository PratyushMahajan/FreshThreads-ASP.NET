using FreshThreads.Services.Interface;
using FreshThreads.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FreshThreads.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "RequireShopOwnerRole")]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        // Constructor using Dependency Injection for IShopService
        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        // GET: api/shop
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopDto>>> GetShops()
        {
            // Get all shops from the service layer and map it to ShopDto
            var shops = await _shopService.GetAllShops();
            return Ok(shops);
        }

        // GET: api/shop/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopDto>> GetShop(long id)
        {
            // Get shop by ID from the service layer and map it to ShopDto
            var shop = await _shopService.GetShopById(id);
            if (shop == null)
            {
                return NotFound();
            }
            return Ok(shop);
        }

        // POST: api/shop
        [HttpPost]
        public async Task<ActionResult<ShopDto>> CreateShop([FromBody] ShopDto shopDto)
        {
            // Create shop using ShopDto and map back to ShopDto after saving
            var createdShop = await _shopService.CreateShop(shopDto);
            return CreatedAtAction(nameof(GetShop), new { id = createdShop.ShopId }, createdShop);
        }

        // PUT: api/shop/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShop(long id, [FromBody] ShopDto shopDto)
        {
            // Check if the provided ID matches the one in the DTO
            if (id != shopDto.ShopId)
            {
                return BadRequest();
            }

            // Update shop using ShopDto
            await _shopService.UpdateShop(shopDto);
            return NoContent();
        }

        // DELETE: api/shop/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop(long id)
        {
            // Check if the shop exists
            var shop = await _shopService.GetShopById(id);
            if (shop == null)
            {
                return NotFound();
            }

            // Delete the shop using ID
            await _shopService.DeleteShop(id);
            return NoContent();
        }
    }
}
