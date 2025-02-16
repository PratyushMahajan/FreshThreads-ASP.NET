using FreshThreads.DTO;
using FreshThreads.Models;
using FreshThreads.Repositories.Interface;
using FreshThreads.Services.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshThreads.Services.Implementation
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;

        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task<IEnumerable<ShopDto>> GetAllShops()
        {
            var shops = await _shopRepository.GetAllShops();
            return shops.Select(s => new ShopDto
            {
                ShopId = s.ShopId,
                ShopName = s.ShopName,
                UserId = (long)s.UserId,
                Status = s.Status,
                CreatedOn = s.CreatedOn,
                UpdatedOn = s.UpdatedOn
            }).ToList();
        }

        public async Task<ShopDto> GetShopById(long id)
        {
            var shop = await _shopRepository.GetShopById(id);
            if (shop == null)
                return null;

            return new ShopDto
            {
                ShopId = shop.ShopId,
                ShopName = shop.ShopName,
                UserId = (long)shop.UserId,
                Status = shop.Status,
                CreatedOn = shop.CreatedOn,
                UpdatedOn = shop.UpdatedOn
            };
        }

        public async Task<ShopDto> CreateShop(ShopDto shopDto)
        {
            var shop = new Shop
            {
                ShopName = shopDto.ShopName,
                Status = shopDto.Status,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };

            var createdShop = await _shopRepository.CreateShop(shop);
            return new ShopDto
            {
                ShopId = createdShop.ShopId,
                ShopName = createdShop.ShopName,
                Status = createdShop.Status,
                CreatedOn = createdShop.CreatedOn,
                UpdatedOn = createdShop.UpdatedOn
            };
        }

        public async Task<ShopDto> UpdateShop(long id, ShopDto shopDto)
        {
            var existingShop = await _shopRepository.GetShopById(id);

            if (existingShop == null)
            {
                return null;
            }

            existingShop.ShopName = shopDto.ShopName;
            existingShop.Status = shopDto.Status;
            existingShop.UpdatedOn = DateTime.UtcNow;

            var updatedShop = await _shopRepository.UpdateShop(existingShop);

            return new ShopDto
            {
                ShopId = updatedShop.ShopId,
                ShopName = updatedShop.ShopName,
                Status = updatedShop.Status,
                CreatedOn = updatedShop.CreatedOn,
                UpdatedOn = updatedShop.UpdatedOn
            };
        }

        public async Task<bool> DeleteShop(long id)
        {
            return await _shopRepository.DeleteShop(id);
        }
    }
}