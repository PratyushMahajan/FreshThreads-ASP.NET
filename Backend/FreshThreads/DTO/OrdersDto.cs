namespace FreshThreads.DTO
{
    public class OrdersDto
    {
        public long OrdersId { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
        public long TotalAmount { get; set; }
        public long UserId { get; set; }
        public long ShopId { get; set; }
        public long DeliveryId { get; set; }
    }
}

