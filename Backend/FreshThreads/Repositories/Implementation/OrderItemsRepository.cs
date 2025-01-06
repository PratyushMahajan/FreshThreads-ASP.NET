using Microsoft.EntityFrameworkCore;
using FreshThreads.Models;
using FreshThreads.Contexts;

namespace FreshThreads.Repositories.Implementation
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly ApplicationDBContext _context;

        public OrderItemsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderItems>> GetOrderItems()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task<OrderItems> GetOrderItemById(long id)
        {
            return await _context.OrderItems.FindAsync(id);
        }

        public async Task AddOrderItem(OrderItems orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderItem(OrderItems orderItem)
        {
            _context.OrderItems.Update(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderItem(long id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);
                await _context.SaveChangesAsync();
            }
            
            
        }
    }
}
