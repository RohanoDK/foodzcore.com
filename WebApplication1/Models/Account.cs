using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace foodzcore.Models
{
    public class Account
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Role { get; set; } = "user";

        // Additional registration properties
        [NotMapped] // Not mapped to the database
        [Compare("Password")] // Ensure the value matches the 'Password' property
        public string ConfirmPassword { get; set; }


        public Account() 
        {
            
        }
    }
}

