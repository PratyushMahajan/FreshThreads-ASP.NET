using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FreshThreads.Models;

public class Orders
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long OrdersId { get; set; } 

    [Required(ErrorMessage = "Order status is required.")]
    [StringLength(80, ErrorMessage = "Order status cannot exceed 80 characters.")]
    [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Order status can only contain letters, numbers, and spaces.")]
    public string Status { get; set; }

    [Required(ErrorMessage = "Order date is required.")]
    [Column(TypeName = "date")] 
    public DateTime OrderDate { get; set; }

    [Required(ErrorMessage = "Total amount is required.")]
    [Range(0, long.MaxValue, ErrorMessage = "Total amount must be a positive value.")]
    public long TotalAmount { get; set; } 

    // Many-to-One relationship with Users
    [ForeignKey("UserId")]
    [Required(ErrorMessage = "User ID is required.")]
    public long UserId { get; set; } // Foreign key
    public Users User { get; set; } // Navigation property

    // Many-to-One relationship with Shop
    [ForeignKey("ShopId")]
    [Required(ErrorMessage = "Shop ID is required.")]
    public long ShopId { get; set; } // Foreign key
    public Shop Shop { get; set; } // Navigation property

    // Many-to-One relationship with Delivery
    [ForeignKey("DeliveryId")]
    [Required(ErrorMessage = "Delivery ID is required.")]
    public long DeliveryId { get; set; } // Foreign key
    public Delivery Delivery { get; set; } // Navigation property

    public ICollection<OrderItems> OrderItems { get; set; } // One-to-Many relationship with OrderItems


    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)] 
    public DateTime CreatedOn { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)] 
    public DateTime UpdatedOn { get; set; }
}
