using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Index(nameof(ShopName), IsUnique = true)]
public class Shop
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ShopId { get; set; } // Primary key

    [Required(ErrorMessage = "Shop name is required.")]
    [StringLength(80, ErrorMessage = "Shop name cannot exceed 80 characters.")]
    [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Shop name can only contain letters, numbers, and spaces.")]
    public string? ShopName { get; set; }

    //[StringLength(80)]
    //public string? OwnerName { get; set; }

    [StringLength(80)]
    [RegularExpression("(?i)^Open$|^Closed$|^Pending$", ErrorMessage = "Invalid shop status. Valid values are Open, Closed, or Pending.")]
    public string? Status { get; set; }

    // One-to-Many relationship with Orders
    //[Required(ErrorMessage = "At least one order must be associated with the shop.")]
    public ICollection<Orders>? Orders { get; set; }

    //// One-to-Many relationship with Users
    //public ICollection<Users>? Users { get; set; }  // This defines the one-to-many relationship with Users

    [ForeignKey("UserId")] // Foreign key for Users
    //[Required(ErrorMessage = "A User must be associated with the shop.")]
    public long? UserId { get; set; }
    public Users? User { get; set; } // Navigation property to Users

    // Common fields (CreatedOn, UpdatedOn)
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedOn { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedOn { get; set; }
}
