using FreshThreads.DTO;

namespace FreshThreads.Services.Interface
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrdersDto>> GetAllOrders();
        Task<OrdersDto> GetOrderById(long id);
        Task<OrdersDto> CreateOrder(OrderRequestDto order);
        Task<OrdersDto> UpdateOrder(long id, OrderRequestDto order);
        Task<bool> DeleteOrder(long id);

    }
}
