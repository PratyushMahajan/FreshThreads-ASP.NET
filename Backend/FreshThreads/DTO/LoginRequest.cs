using System.ComponentModel.DataAnnotations;
using FreshThreads.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTImplementation.Interfaces
{
    public class LoginRequest
    {

        [StringLength(80)]
        public string Email { get; set; } // Matches @Column(length=80)

        [StringLength(550)]
        public string Password { get; set; } // Matches @Column(length=550)

        [Column(TypeName = "nvarchar(30)")] // Ensures enum is stored as a string
        public UserRole Role { get; set; }
    }
}