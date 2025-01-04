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

        public async Task<IEnumerable<Delivery>> GetAllDeliveries()
        {
            return await _deliveryRepository.GetAllDeliveries();
        }

        public async Task<Delivery> GetDeliveryById(long id)
        {
            return await _deliveryRepository.GetDeliveryById(id);
        }

        public async Task<Delivery> CreateDelivery(Delivery delivery)
        {
            return await _deliveryRepository.CreateDelivery(delivery);
        }

        public async Task<Delivery> UpdateDelivery(long id, Delivery delivery)
        {
            return await _deliveryRepository.UpdateDelivery(id, delivery);
        }

        public async Task<bool> DeleteDelivery(long id)
        {
            return await _deliveryRepository.DeleteDelivery(id);
        }
    }
}
