namespace Domain.Entities
{
    public class AICallLog
    {
        public int LogId { get; set; }
        public int ConfigId { get; set; }            // FK to AIConfig
        public int? StudentId { get; set; }          // optional who triggered
        public int? MatrixId { get; set; }           // optional exam matrix context
        public string? RequestText { get; set; }
        public string? ResponseText { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
