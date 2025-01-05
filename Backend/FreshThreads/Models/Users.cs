using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FreshThreads.Models;

public class Users
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Matches @GeneratedValue
    public long UsersId { get; set; } // Primary key

    [StringLength(80)]
    public string ?Name { get; set; } // Matches @Column(length=80)

    [StringLength(80)]
    public string? Email { get; set; } // Matches @Column(length=80)

    [StringLength(550)]
    public string? Password { get; set; } // Matches @Column(length=550)

    [StringLength(10)]
    public string? Phonenumber { get; set; } // Matches @Column(length=10, name = "phone_number")

    [StringLength(500)]
    public string ?Address { get; set; } // Matches @Column(length=500)

    [StringLength(80)]
    public string ?City { get; set; } // Matches @Column(length=80)

    [Column(TypeName = "nvarchar(30)")] // Ensures enum is stored as a string
    public UserRole Role { get; set; } // Matches @Enumerated(EnumType.STRING)

    //[ForeignKey("ShopId")]
    //public long ? ShopId { get; set; } // Foreign key
    //public Shop? Shop { get; set; } // Navigation property

    public ICollection<Shop>? Shops { get; set; } // Matches one-to-many from users to shops

    // One-to-Many relationship with Orders
    public ICollection<Orders> ?Orders { get; set; } // Matches @OneToMany(mappedBy = "user")

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)] // Matches @CreationTimestamp
    public DateTime CreatedOn { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)] // Matches @UpdateTimestamp
    public DateTime UpdatedOn { get; set; }
}
