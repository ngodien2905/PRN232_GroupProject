namespace Domain.Entities
{
    public class Syllabus
    {
        public int SyllabusId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
