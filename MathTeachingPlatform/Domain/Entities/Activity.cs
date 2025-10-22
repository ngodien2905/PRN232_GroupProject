namespace Domain.Entities
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public int TeacherId { get; set; }
        public int? ClassId { get; set; }
        public int? AttemptId { get; set; }          // link to exam attempt id (Exam DB)
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
