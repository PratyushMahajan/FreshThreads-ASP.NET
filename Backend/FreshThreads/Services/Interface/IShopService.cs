namespace FreshThreads.Services.Interface
{
    public interface IShopService
    {
        Task<IEnumerable<Shop>> GetAllShops();
        Task<Shop> GetShopById(long id);
        Task<Shop> CreateShop(Shop shop);
        Task<Shop> UpdateShop(Shop shop);
        Task<bool> DeleteShop(long id);

    }
}
