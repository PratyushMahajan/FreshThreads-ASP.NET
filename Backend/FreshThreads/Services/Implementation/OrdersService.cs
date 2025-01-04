using FreshThreads.Repositories.Interface;
using FreshThreads.Services.Interface;

namespace FreshThreads.Services.Implementation
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            return await _ordersRepository.GetAllOrders();
        }
        public async Task<Orders> GetOrderById(long id)
        {
            return await _ordersRepository.GetOrderById(id);
        }
        public async Task<Orders> CreateOrder(Orders order)
        {
            return await _ordersRepository.CreateOrder(order);
        }
        public async Task<Orders> UpdateOrder(Orders order)
        {
            return await _ordersRepository.UpdateOrder(order);
        }
        public async Task<bool> DeleteOrder(long id)
        {
            return await _ordersRepository.DeleteOrder(id);
        }
    }
}
