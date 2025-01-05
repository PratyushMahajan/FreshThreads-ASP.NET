using FreshThreads.DTO;

namespace FreshThreads.Services.Interface
{
    public interface IDeliveryService
    {
        Task<IEnumerable<DeliveryDto>> GetAllDeliveries();
        Task<DeliveryDto> GetDeliveryById(long id);
        Task<DeliveryDto> CreateDelivery(DeliveryDto deliveryDto);
        Task<DeliveryDto> UpdateDelivery(long id, DeliveryDto deliveryDto);
        Task<bool> DeleteDelivery(long id);
    }
}
