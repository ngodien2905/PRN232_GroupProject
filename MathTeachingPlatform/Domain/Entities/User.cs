using Domain.Enum;

namespace Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }              // maps users.user_id
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? Email { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
