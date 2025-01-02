using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreshThreads.Models
{
    public class Delivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DeliveryId { get; set; } // Primary key

        [Required]
        public DateTime PickupTime { get; set; }

        [Required]
        public DateTime DropTime { get; set; }

        [Required]
        [StringLength(255)]
        public string DeliveryStatus { get; set; }

        [StringLength(255)]
        public string DeliveryPersonName { get; set; }

        [StringLength(15)]
        public string DeliveryPersonPhone { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedOn { get; set; }

        // One-to-Many relationship with Orders
        public ICollection<Orders> Orders { get; set; }  // This defines the relationship
    }
}
