namespace Domain.Entities
{
    public class Class
    {
        public int ClassId { get; set; }
        public int? SubjectId { get; set; }          // FK to Subject (Content DB)
        public int? TeacherId { get; set; }          // owner teacher id
        public string? Name { get; set; }
        public string? Schedule { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
