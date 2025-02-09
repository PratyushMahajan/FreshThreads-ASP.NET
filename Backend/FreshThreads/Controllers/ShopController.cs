using FreshThreads.Services.Interface;
using FreshThreads.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [Authorize(Policy = "RequireUserRole, RequireShopOwnerRole")]
        public async Task<ActionResult<IEnumerable<ShopDto>>> GetShops()
        {
            var shops = await _shopService.GetAllShops();
            return Ok(shops);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "RequireShopOwnerRole, RequireShopOwnerRole")]
        public async Task<ActionResult<ShopDto>> GetShop(long id)
        {
            var shop = await _shopService.GetShopById(id);
            if (shop == null)
            {
                return NotFound();
            }
            return Ok(shop);
        }

        [HttpPost]
        [Authorize(Policy = "RequireShopOwnerRole")]
        public async Task<ActionResult<ShopDto>> CreateShop([FromBody] ShopDto shopDto)
        {
            var createdShop = await _shopService.CreateShop(shopDto);
            return CreatedAtAction(nameof(GetShop), new { id = createdShop.ShopId }, createdShop);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "RequireShopOwnerRole, RequireAdminRole")]
        public async Task<IActionResult> UpdateShop(long id, [FromBody] ShopDto shopDto)
        {
            if (id != shopDto.ShopId)
            {
                return BadRequest();
            }

            await _shopService.UpdateShop(id, shopDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "RequireShopOwnerRole, RequireAdminRole")]
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
