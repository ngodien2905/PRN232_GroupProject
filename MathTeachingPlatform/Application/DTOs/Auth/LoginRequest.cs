using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Auth
{
    public class LoginRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
