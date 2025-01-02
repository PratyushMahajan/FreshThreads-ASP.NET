using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Shop
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ShopId { get; set; } // Primary key

    [StringLength(80)]
    public string ShopName { get; set; }

    [StringLength(80)]
    public string OwnerName { get; set; }

    [StringLength(80)]
    public string Status { get; set; }

    // One-to-Many relationship with Orders
    public ICollection<Orders> Orders { get; set; }

    // One-to-Many relationship with Users
    public ICollection<Users> Users { get; set; }  // This defines the one-to-many relationship with Users

    // Common fields (CreatedOn, UpdatedOn)
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedOn { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedOn { get; set; }

    [Timestamp]
    public byte[] Version { get; set; }
}
