using System.ComponentModel.DataAnnotations;

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
        public string Role { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }


    }
}

