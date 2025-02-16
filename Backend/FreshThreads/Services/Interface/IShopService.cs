using FreshThreads.DTO;

namespace FreshThreads.Services.Interface
{
    public interface IShopService
    {
        Task<IEnumerable<ShopDto>> GetAllShops();
        Task<ShopDto> GetShopById(long id);
        Task<ShopDto> CreateShop(ShopDto shopDto);
        Task<ShopDto> UpdateShop(long id, ShopDto shopDto);
        Task<bool> DeleteShop(long id);
    }
}
