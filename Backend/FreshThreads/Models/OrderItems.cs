using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderItems
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long OrderItemId { get; set; } // Primary key

    [Required]
    [StringLength(100)]
    public string Service { get; set; }

    [Required]
    [StringLength(100)]
    public string Item { get; set; }

    [Required]
    [Range(1, 100)]
    public int Quantity { get; set; }

    [Required]
    public decimal Price { get; set; }

    // Many-to-One relationship with Orders
    [ForeignKey("OrdersId")]
    public long OrdersId { get; set; } // Foreign key
    public Orders Orders { get; set; } // Navigation property
}
