using FreshThreads.Repositories.Interface;
using FreshThreads.Services.Interface;

namespace FreshThreads.Services.Implementation
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;

        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task<IEnumerable<Shop>> GetAllShops()
        {
            return await _shopRepository.GetAllShops();
        }

        public async Task<Shop> GetShopById(long id)
        {
            return await _shopRepository.GetShopById(id);
        }

        public async Task<Shop> CreateShop(Shop shop)
        {
            return await _shopRepository.CreateShop(shop);
        }

        public async Task<Shop> UpdateShop(Shop shop)
        {
            return await _shopRepository.UpdateShop(shop);
        }

        public async Task<bool> DeleteShop(long id)
        {
            return await _shopRepository.DeleteShop(id);
        }

    }
}
