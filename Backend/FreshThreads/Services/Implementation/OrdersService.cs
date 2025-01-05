using FreshThreads.DTO;
using FreshThreads.Models;
using FreshThreads.Repositories.Interface;
using FreshThreads.Services.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshThreads.Services.Implementation
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<IEnumerable<OrdersDto>> GetAllOrders()
        {
            var orders = await _ordersRepository.GetAllOrders();
            return orders.Select(o => new OrdersDto
            {
                OrdersId = o.OrdersId,
                Status = o.Status,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount,
                UserId = o.UserId,
                ShopId = o.ShopId,
                DeliveryId = o.DeliveryId
            }).ToList();
        }

        public async Task<OrdersDto> GetOrderById(long id)
        {
            var order = await _ordersRepository.GetOrderById(id);
            if (order == null)
            {
                return null;
            }
            return new OrdersDto
            {
                OrdersId = order.OrdersId,
                Status = order.Status,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                UserId = order.UserId,
                ShopId = order.ShopId,
                DeliveryId = order.DeliveryId
            };
        }

        public async Task<OrdersDto> CreateOrder(OrderRequestDto orderDto)
        {
            var order = new Orders
            {
                Status = orderDto.Status,
                OrderDate = orderDto.OrderDate,
                TotalAmount = orderDto.TotalAmount,
                UserId = orderDto.UserId,
                ShopId = orderDto.ShopId,
                DeliveryId = orderDto.DeliveryId
            };

            var createdOrder = await _ordersRepository.CreateOrder(order);
            return new OrdersDto
            {
                OrdersId = createdOrder.OrdersId,
                Status = createdOrder.Status,
                OrderDate = createdOrder.OrderDate,
                TotalAmount = createdOrder.TotalAmount,
                UserId = createdOrder.UserId,
                ShopId = createdOrder.ShopId,
                DeliveryId = createdOrder.DeliveryId
            };
        }

        public async Task<OrdersDto> UpdateOrder(long id, OrderRequestDto orderDto)
        {
            var order = await _ordersRepository.GetOrderById(id);
            if (order == null)
            {
                return null;
            }

            order.Status = orderDto.Status;
            order.OrderDate = orderDto.OrderDate;
            order.TotalAmount = orderDto.TotalAmount;
            order.UserId = orderDto.UserId;
            order.ShopId = orderDto.ShopId;
            order.DeliveryId = orderDto.DeliveryId;

            var updatedOrder = await _ordersRepository.UpdateOrder(order);
            return new OrdersDto
            {
                OrdersId = updatedOrder.OrdersId,
                Status = updatedOrder.Status,
                OrderDate = updatedOrder.OrderDate,
                TotalAmount = updatedOrder.TotalAmount,
                UserId = updatedOrder.UserId,
                ShopId = updatedOrder.ShopId,
                DeliveryId = updatedOrder.DeliveryId
            };
        }

        public async Task<bool> DeleteOrder(long id)
        {
            return await _ordersRepository.DeleteOrder(id);
        }
    }
}
