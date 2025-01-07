using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FreshThreads.Models;

public class Users
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long UsersId { get; set; } // Primary key

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(80, ErrorMessage = "Name cannot exceed 80 characters.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
    public string ?Name { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [StringLength(80, ErrorMessage = "Email cannot exceed 80 characters.")]
    [RegularExpression(
        @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        ErrorMessage = "Invalid email format. Please use a valid email address like user@example.com."
    )]
    public string? Email { get; set; } 

    [StringLength(550, ErrorMessage = "Password cannot exceed 550 characters.")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
    public string? Password { get; set; } 

    [Required(ErrorMessage = "Phone number is required.")]
    [StringLength(10, ErrorMessage = "Phone number must be exactly 10 digits.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
    public string? Phonenumber { get; set; } 

    [Required(ErrorMessage = "Address is required.")]
    [StringLength(500, ErrorMessage = "Address cannot exceed 500 characters.")]
    public string ?Address { get; set; } 

    [Required(ErrorMessage = "City is required.")]
    [StringLength(80, ErrorMessage = "City cannot exceed 80 characters.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City can only contain letters and spaces.")]
    public string ?City { get; set; } 
    [Required(ErrorMessage = "Role is required.")]
    [Column(TypeName = "nvarchar(30)")]
    public UserRole Role { get; set; } 

    //[ForeignKey("ShopId")]
    //public long ? ShopId { get; set; } // Foreign key
    //public Shop? Shop { get; set; } // Navigation property

    public ICollection<Shop>? Shops { get; set; }//one-to-many from users to shops

    // One-to-Many relationship with Orders
    public ICollection<Orders> ?Orders { get; set; } //@OneToMany(mappedBy = "user")

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)] 
    public DateTime CreatedOn { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedOn { get; set; }
}
