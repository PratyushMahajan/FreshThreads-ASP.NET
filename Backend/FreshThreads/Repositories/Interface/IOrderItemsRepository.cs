public interface IOrderItemsRepository
{
    Task<IEnumerable<OrderItems>> GetOrderItems();
    Task<OrderItems> GetOrderItemById(long id);
    Task AddOrderItem(OrderItems orderItem);
    Task UpdateOrderItem(OrderItems orderItem);
    Task DeleteOrderItem(long id);
}
