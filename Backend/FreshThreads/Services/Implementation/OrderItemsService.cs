using AutoMapper;
using FreshThreads.Services.Interface;

namespace FreshThreads.Services.Implementation
{    
    public class OrderItemsService : IOrderItemsService
    {
        private readonly IOrderItemsRepository _repository;
        private readonly IMapper _mapper;

        public OrderItemsService(IOrderItemsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderItemsDto>> GetOrderItems()
        {
            var orderItems = await _repository.GetOrderItems();
            return _mapper.Map<IEnumerable<OrderItemsDto>>(orderItems);
        }

        public async Task<OrderItemsDto> GetOrderItemById(long id)
        {
            var orderItem = await _repository.GetOrderItemById(id);
            return _mapper.Map<OrderItemsDto>(orderItem);
        }

        public async Task AddOrderItem(OrderItemsDto orderItemDto)
        {
            var orderItem = _mapper.Map<OrderItems>(orderItemDto);
            await _repository.AddOrderItem(orderItem);
        }

        public async Task UpdateOrderItem(OrderItemsDto orderItemDto)
        {
            var orderItem = _mapper.Map<OrderItems>(orderItemDto);
            await _repository.UpdateOrderItem(orderItem);
        }

        public async Task DeleteOrderItem(long id)
        {
             await _repository.DeleteOrderItem(id);
        }
    }

}
