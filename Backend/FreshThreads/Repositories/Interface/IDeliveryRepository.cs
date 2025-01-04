using FreshThreads.Models;

namespace FreshThreads.Repositories.Interface
{
    public interface IDeliveryRepository
    {
        Task<IEnumerable<Delivery>> GetAllDeliveries();
        Task<Delivery> GetDeliveryById(long id);
        Task<Delivery> CreateDelivery(Delivery delivery);
        Task<Delivery> UpdateDelivery(long id, Delivery delivery);
        Task<bool> DeleteDelivery(long id);
    }
}
