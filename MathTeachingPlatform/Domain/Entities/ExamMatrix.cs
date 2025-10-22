namespace Domain.Entities
{
    public class ExamMatrix
    {
        public int MatrixId { get; set; }
        public int SubjectId { get; set; }
        public string? Title { get; set; }
        public DateTime GeneratedOn { get; set; } = DateTime.UtcNow;
        public int TotalQuestions { get; set; }
    }
}
