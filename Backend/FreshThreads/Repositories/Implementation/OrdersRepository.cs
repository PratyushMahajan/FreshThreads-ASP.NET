using FreshThreads.Contexts;
using FreshThreads.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FreshThreads.Repositories.Implementation
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ApplicationDBContext Dbcontext;
        public OrdersRepository(ApplicationDBContext context) 
        {
            Dbcontext = context;
        }
        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            return await Dbcontext.Orders.ToListAsync();

        }
        public async Task<Orders> GetOrderById(long id)
        {
            return await Dbcontext.Orders.FirstOrDefaultAsync(o => o.OrdersId == id);
        }

        public async Task<Orders> CreateOrder(Orders order)
        {
            Dbcontext.Orders.Add(order);
            await Dbcontext.SaveChangesAsync();
            return order;
        }

        public async Task<Orders> UpdateOrder(Orders order)
        {
            Dbcontext.Entry(order).State = EntityState.Modified;
            await Dbcontext.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteOrder(long id)
        {
            var order = await Dbcontext.Orders.FindAsync(id);
            if (order == null)
            {
                return false;
            }
            Dbcontext.Orders.Remove(order);
            await Dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
