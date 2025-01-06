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
        [CustomValidation(typeof(Delivery), nameof(ValidatePickupTime))]
        public DateTime PickupTime { get; set; }

        [Required]
        [CustomValidation(typeof(Delivery), nameof(ValidateDropTime))]
        public DateTime DropTime { get; set; }

        public static ValidationResult? ValidatePickupTime(DateTime pickupTime, ValidationContext context)
        {
            if (pickupTime < DateTime.Now)
            {
                return new ValidationResult("Pickup time cannot be in the past.");
            }
            return ValidationResult.Success;
        }

        public static ValidationResult? ValidateDropTime(DateTime dropTime, ValidationContext context)
        {
            var instance = (Delivery)context.ObjectInstance;

            // Check if DropTime is in the past
            if (dropTime < DateTime.Now)
            {
                return new ValidationResult("Drop time cannot be in the past.");
            }

            // Check if DropTime is after PickupTime
            if (instance.PickupTime >= dropTime)
            {
                return new ValidationResult("Drop time must be after Pickup time.");
            }

            return ValidationResult.Success;
        }

        [Required]
        [StringLength(255)]
        [RegularExpression("(?i)^Pending$|^In Transit$|^Delivered$|^Failed$", ErrorMessage = "Invalid delivery status.")]
        public string ?DeliveryStatus { get; set; }

        [StringLength(255)]
        [Range(typeof(DateTime), "01/01/2000", "12/31/2099", ErrorMessage = "Pickup time must be between the year 2000 and 2099.")]
        public string ?DeliveryPersonName { get; set; }

        [StringLength(15)]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number format.")]
        public string ?DeliveryPersonPhone { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedOn { get; set; }

        // One-to-Many relationship with Orders
        //[Required(ErrorMessage = "At least one order must be associated with the delivery.")]
        public ICollection<Orders> ?Orders { get; set; }  // This defines the relationship
    }
}
