using FreshThreads.DTO;

namespace FreshThreads.Services.Interface
{
    public interface IShopService
    {
        Task<IEnumerable<Shop>> GetAllShops();
        Task<ShopDto> GetShopById(long id);
        Task<ShopDto> CreateShop(ShopDto shopDto);
        Task<ShopDto> UpdateShop(ShopDto shopDto);
        Task<bool> DeleteShop(long id);

    }
}
