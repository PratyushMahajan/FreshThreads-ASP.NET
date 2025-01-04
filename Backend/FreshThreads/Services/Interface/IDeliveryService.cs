using FreshThreads.Models;

namespace FreshThreads.Services.Interface
{
    public interface IDeliveryService
    {
        Task<IEnumerable<Delivery>> GetAllDeliveries();
        Task<Delivery> GetDeliveryById(long id);
        Task<Delivery> CreateDelivery(Delivery delivery);
        Task<Delivery> UpdateDelivery(long id, Delivery delivery);
        Task<bool> DeleteDelivery(long id);
    }
}
