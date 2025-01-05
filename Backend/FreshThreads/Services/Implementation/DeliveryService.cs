using FreshThreads.DTO;
using FreshThreads.Models;
using FreshThreads.Repositories.Interface;
using FreshThreads.Services.Interface;

namespace FreshThreads.Services.Implementation
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;

        public DeliveryService(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public async Task<IEnumerable<DeliveryDto>> GetAllDeliveries()
        {
            var deliveries = await _deliveryRepository.GetAllDeliveries();
            return deliveries.Select(d => new DeliveryDto
            {
                DeliveryId = d.DeliveryId,
                DeliveryDate = d.DropTime,
                DeliveryStatus = d.DeliveryStatus,
                DeliveryPersonName = d.DeliveryPersonName,
                DeliveryPersonPhone = d.DeliveryPersonPhone,
            }).ToList();
        }

        public async Task<DeliveryDto> GetDeliveryById(long id)
        {
            var delivery = await _deliveryRepository.GetDeliveryById(id);
            if (delivery == null)
                return null;

            return new DeliveryDto
            {
                DeliveryId = delivery.DeliveryId,
                DeliveryDate = delivery.DropTime,
                DeliveryStatus = delivery.DeliveryStatus,
                DeliveryPersonName = delivery.DeliveryPersonName,
                DeliveryPersonPhone = delivery.DeliveryPersonPhone,
            };
        }

        public async Task<DeliveryDto> CreateDelivery(DeliveryDto deliveryDto)
        {
            var delivery = new Delivery
            {
                PickupTime = deliveryDto.DeliveryDate,
                DropTime = deliveryDto.DeliveryDate,
                DeliveryStatus = deliveryDto.DeliveryStatus,
                DeliveryPersonName = deliveryDto.DeliveryPersonName,
                DeliveryPersonPhone = deliveryDto.DeliveryPersonPhone
            };

            var createdDelivery = await _deliveryRepository.CreateDelivery(delivery);
            return new DeliveryDto
            {
                DeliveryId = createdDelivery.DeliveryId,
                DeliveryDate = createdDelivery.DropTime,
                DeliveryStatus = createdDelivery.DeliveryStatus,
                DeliveryPersonName = createdDelivery.DeliveryPersonName,
                DeliveryPersonPhone = createdDelivery.DeliveryPersonPhone,
            };
        }

        public async Task<DeliveryDto> UpdateDelivery(long id, DeliveryDto deliveryDto)
        {
            // Retrieve the existing delivery record
            var existingDelivery = await _deliveryRepository.GetDeliveryById(id);

            if (existingDelivery == null)
            {
                return null; // Return null if delivery doesn't exist
            }

            // Map fields from the DTO to the entity
            existingDelivery.PickupTime = deliveryDto.DeliveryDate;
            existingDelivery.DropTime = deliveryDto.DeliveryDate;
            existingDelivery.DeliveryStatus = deliveryDto.DeliveryStatus;
            existingDelivery.DeliveryPersonName = deliveryDto.DeliveryPersonName;
            existingDelivery.DeliveryPersonPhone = deliveryDto.DeliveryPersonPhone;

            // Update the delivery entity
            var updatedDelivery = await _deliveryRepository.UpdateDelivery(id, existingDelivery);

            // Map updated entity back to DTO
            return new DeliveryDto
            {
                DeliveryId = updatedDelivery.DeliveryId,
                DeliveryDate = updatedDelivery.DropTime,
                DeliveryStatus = updatedDelivery.DeliveryStatus,
                DeliveryPersonName = updatedDelivery.DeliveryPersonName,
                DeliveryPersonPhone = updatedDelivery.DeliveryPersonPhone,
            };
        }


        public async Task<bool> DeleteDelivery(long id)
        {
            return await _deliveryRepository.DeleteDelivery(id);
        }
    }
}
