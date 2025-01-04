using FreshThreads.Contexts;
using FreshThreads.Models;
using FreshThreads.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FreshThreads.Repositories.Implementation
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly ApplicationDBContext Dbcontext;

        public DeliveryRepository(ApplicationDBContext context)
        {
            Dbcontext = context;
        }

        public async Task<IEnumerable<Delivery>> GetAllDeliveries()
        {
            return await Dbcontext.Deliveries.ToListAsync();
        }

        public async Task<Delivery> GetDeliveryById(long id)
        {
            return await Dbcontext.Deliveries.FirstOrDefaultAsync(d => d.DeliveryId == id);
        }

        public async Task<Delivery> CreateDelivery(Delivery delivery)
        {
            Dbcontext.Deliveries.Add(delivery);
            await Dbcontext.SaveChangesAsync();
            return delivery;
        }

        public async Task<Delivery> UpdateDelivery(long id, Delivery delivery)
        {
            Dbcontext.Entry(delivery).State = EntityState.Modified;
            await Dbcontext.SaveChangesAsync();
            return delivery;
        }

        public async Task<bool> DeleteDelivery(long id)
        {
            var delivery = await Dbcontext.Deliveries.FindAsync(id);
            if (delivery == null)
            {
                return false;
            }
            Dbcontext.Deliveries.Remove(delivery);
            await Dbcontext.SaveChangesAsync();
            return true;
        }

    }
}
