using FreshThreads.Contexts;
using FreshThreads.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FreshThreads.Repositories.Implementation
{
    public class ShopRepository : IShopRepository
    {
        private readonly ApplicationDBContext Dbcontext;

        public ShopRepository(ApplicationDBContext context)
        {
            Dbcontext = context;
        }

        public async Task<IEnumerable<Shop>> GetAllShops()
        {
            return await Dbcontext.Shops.ToListAsync();
        }

        public async Task<Shop> GetShopById(long id)
        {
            return await Dbcontext.Shops.FirstOrDefaultAsync(s => s.ShopId == id);
        }

        public async Task<Shop> CreateShop(Shop shop)
        {
            Dbcontext.Shops.Add(shop);
            await Dbcontext.SaveChangesAsync();
            return shop;
        }

        public async Task<Shop> UpdateShop(Shop shop)
        {
            Dbcontext.Entry(shop).State = EntityState.Modified;
            await Dbcontext.SaveChangesAsync();
            return shop;
        }

        public async Task<bool> DeleteShop(long id)
        {
            var shop = await Dbcontext.Shops.FindAsync(id);
            if (shop == null)
            {
                return false;
            }
            Dbcontext.Shops.Remove(shop);
            await Dbcontext.SaveChangesAsync();
            return true;
        }

    }
}
