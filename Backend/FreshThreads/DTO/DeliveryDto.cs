namespace FreshThreads.DTO
{
    public class DeliveryDto
    {
        public long DeliveryId { get; set; } // Primary key
        public long OrderId { get; set; } // Order ID
        public long UserId { get; set; } // User ID
        public DateTime DeliveryDate { get; set; } // Delivery date
        public string DeliveryStatus { get; set; } // Delivery status
        public string DeliveryPersonName { get; set; } // Delivery person's name
        public string DeliveryPersonPhone { get; set; } // Delivery person's phone
    }
}
