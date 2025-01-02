using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FreshThreads.Models;

public class Orders
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Matches @GeneratedValue
    public long OrdersId { get; set; } // Primary key

    [StringLength(30)] // Matches @Column(length=30)
    public string Status { get; set; }

    [Column(TypeName = "date")] // Matches `LocalDate` in Java
    public DateTime OrderDate { get; set; }

    public long TotalAmount { get; set; } // Matches `Long totalAmount` in Java

    // Many-to-One relationship with Users
    [ForeignKey("UserId")]
    public long UserId { get; set; } // Foreign key
    public Users User { get; set; } // Navigation property

    // Many-to-One relationship with Shop
    [ForeignKey("ShopId")]
    public long ShopId { get; set; } // Foreign key
    public Shop Shop { get; set; } // Navigation property

    // Many-to-One relationship with Delivery
    [ForeignKey("DeliveryId")]
    public long DeliveryId { get; set; } // Foreign key
    public Delivery Delivery { get; set; } // Navigation property


    // Common fields (CreatedOn, UpdatedOn)
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)] // Matches @CreationTimestamp
    public DateTime CreatedOn { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)] // Matches @UpdateTimestamp
    public DateTime UpdatedOn { get; set; }
}
