using System.Text.Json.Serialization;
using FreshThreads.Models;

namespace FreshThreads.DTO
{
    public class UserDto
    {
        public long UsersId { get; set; } // Primary key
        public string? Name { get; set; } // User name
        public string? Email { get; set; } // Email address
        public string ?Phonenumber { get; set; } // Phone number
        public string? Address { get; set; } // Address
        public string? Password { get; set; }

        public string? City { get; set; } // City
        public UserRole Role { get; set; } // User role
        public DateTime CreatedOn { get; set; } // Created timestamp
        public DateTime UpdatedOn { get; set; } // Updated timestamp
    }
}
