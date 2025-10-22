namespace Domain.Entities
{
    public class AIConfig
    {
        public int ConfigId { get; set; }
        public int TeacherId { get; set; }           // owner
        public string? ModelName { get; set; }
        public decimal? Temperature { get; set; }    // decimal(3,2)
        public int? MaxTokens { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? SettingsJson { get; set; }    // extra settings, apiKeyRef, endpoint
    }
}
