  
namespace FreshThreads.DTO
{
    public class ShopDto
    {
        public long ShopId { get; set; }
        public string ShopName { get; set; }
        public string OwnerName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
