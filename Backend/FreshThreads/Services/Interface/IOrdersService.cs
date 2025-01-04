namespace FreshThreads.Services.Interface
{
    public interface IOrdersService
    {
        Task<IEnumerable<Orders>> GetAllOrders();
        Task<Orders> GetOrderById(long id);
        Task<Orders> CreateOrder(Orders order);
        Task<Orders> UpdateOrder(Orders order);
        Task<bool> DeleteOrder(long id);

    }
}
