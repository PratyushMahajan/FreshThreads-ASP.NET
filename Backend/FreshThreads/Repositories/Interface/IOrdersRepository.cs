namespace FreshThreads.Repositories.Interface
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Orders>> GetAllOrders();
        Task<Orders> GetOrderById(long id);
        Task<Orders> CreateOrder(Orders order);
        Task<Orders> UpdateOrder(Orders order);
        Task<bool> DeleteOrder(long id);
    }
}
