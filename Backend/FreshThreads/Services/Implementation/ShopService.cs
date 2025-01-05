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
                OwnerName = s.OwnerName,
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
                OwnerName = shop.OwnerName,
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
                OwnerName = shopDto.OwnerName,
                Status = shopDto.Status,
                CreatedOn = DateTime.UtcNow, // Assuming you want to set CreatedOn to now
                UpdatedOn = DateTime.UtcNow  // Assuming you want to set UpdatedOn to now
            };

            var createdShop = await _shopRepository.CreateShop(shop);
            return new ShopDto
            {
                ShopId = createdShop.ShopId,
                ShopName = createdShop.ShopName,
                OwnerName = createdShop.OwnerName,
                Status = createdShop.Status,
                CreatedOn = createdShop.CreatedOn,
                UpdatedOn = createdShop.UpdatedOn
            };
        }

        public async Task<ShopDto> UpdateShop(long id, ShopDto shopDto)
        {
            // Retrieve the existing shop record
            var existingShop = await _shopRepository.GetShopById(id);

            if (existingShop == null)
            {
                return null; // Return null if shop doesn't exist
            }

            // Map fields from the DTO to the entity
            existingShop.ShopName = shopDto.ShopName;
            existingShop.OwnerName = shopDto.OwnerName;
            existingShop.Status = shopDto.Status;
            existingShop.UpdatedOn = DateTime.UtcNow; // Update the timestamp

            // Update the shop entity
            var updatedShop = await _shopRepository.UpdateShop(existingShop);

            // Map updated entity back to DTO
            return new ShopDto
            {
                ShopId = updatedShop.ShopId,
                ShopName = updatedShop.ShopName,
                OwnerName = updatedShop.OwnerName,
                Status = updatedShop.Status,
                CreatedOn = updatedShop.CreatedOn,
                UpdatedOn = updatedShop.UpdatedOn
            };
        }

        public async Task<bool> DeleteShop(long id)
        {
            return await _shopRepository.DeleteShop(id);
        }

        // Implementing the missing interface method
        async Task<IEnumerable<Shop>> IShopService.GetAllShops()
        {
            return await _shopRepository.GetAllShops();
        }

        // Implementing the missing interface method
        async Task<ShopDto> IShopService.UpdateShop(ShopDto shopDto)
        {
            var shop = new Shop
            {
                ShopName = shopDto.ShopName,
                OwnerName = shopDto.OwnerName,
                Status = shopDto.Status,
                UpdatedOn = DateTime.UtcNow // Assuming you want to set UpdatedOn to now
            };

            var updatedShop = await _shopRepository.UpdateShop(shop);
            return new ShopDto
            {
                ShopId = updatedShop.ShopId,
                ShopName = updatedShop.ShopName,
                OwnerName = updatedShop.OwnerName,
                Status = updatedShop.Status,
                CreatedOn = updatedShop.CreatedOn,
                UpdatedOn = updatedShop.UpdatedOn
            };
        }
    }
}