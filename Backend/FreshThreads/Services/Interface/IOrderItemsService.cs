namespace FreshThreads.Services.Interface
{
    public interface IOrderItemsService
    {
        Task<IEnumerable<OrderItemsDto>> GetOrderItems();
        Task<OrderItemsDto> GetOrderItemById(long id);
        Task AddOrderItem(OrderItemsDto orderItemDto);
        Task UpdateOrderItem(OrderItemsDto orderItemDto);
        Task DeleteOrderItem(long id);
    }
}
