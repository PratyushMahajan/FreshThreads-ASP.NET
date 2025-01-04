using FreshThreads.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FreshThreads.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shop>>> GetShops()
        {
            var shops = await _shopService.GetAllShops();
            return Ok(shops);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shop>> GetShop(long id)
        {
            var shop = await _shopService.GetShopById(id);
            if (shop == null)
            {
                return NotFound();
            }
            return Ok(shop);
        }

        [HttpPost]
        public async Task<ActionResult<Shop>> CreateShop(Shop shop)
        {
            var createdShop = await _shopService.CreateShop(shop);
            return CreatedAtAction(nameof(GetShop), new { id = createdShop.ShopId }, createdShop);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShop(long id, Shop shop)
        {
            if (id != shop.ShopId)
            {
                return BadRequest();
            }
            await _shopService.UpdateShop(shop);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop(long id)
        {
            var shop = await _shopService.GetShopById(id);
            if (shop == null)
            {
                return NotFound();
            }
            await _shopService.DeleteShop(id);
            return NoContent();
        }
    }
}
