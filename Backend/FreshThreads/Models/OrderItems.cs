using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderItems
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long OrderItemId { get; set; } // Primary key

    [Required(ErrorMessage = "Service is required.")]
    [StringLength(100, ErrorMessage = "Service cannot exceed 100 characters.")]
    public string Service { get; set; }

    [Required(ErrorMessage = "Item is required.")]
    [StringLength(100, ErrorMessage = "Item cannot exceed 100 characters.")]
    public string Item { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
    public decimal Price { get; set; }

    // Many-to-One relationship with Orders
    [ForeignKey("OrdersId")]
    [Required(ErrorMessage = "Orders ID is required.")]
    public long OrdersId { get; set; } // Foreign key
    public Orders Orders { get; set; } // Navigation property
}
