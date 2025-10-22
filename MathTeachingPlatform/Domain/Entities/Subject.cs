namespace Domain.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
