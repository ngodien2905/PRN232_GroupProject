using System.ComponentModel.DataAnnotations;
using Application.Validation;

namespace Application.DTOs.Auth
{
    public class RegisterRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be 3-50 characters.")]
        public string Username { get; set; } = null!;

        [Required]
        [PasswordComplexity(MinLength = 8, RequireDigit = true, RequireUppercase = true, RequireLowercase = true)]
        public string Password { get; set; } = null!;

        [Required]
        [RegularExpression("Teacher|Student|Admin", ErrorMessage = "Role must be Teacher, Student or Admin.")]
        public string Role { get; set; } = "Student";

        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }
    }
}
