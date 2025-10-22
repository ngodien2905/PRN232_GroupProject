namespace Domain.Entities
{
    public class AIHistoryChat
    {
        public int ChatId { get; set; }
        public int TeacherId { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
