using Domain.Enum;

namespace Domain.Entities
{
    public class ExamQuestion
    {
        public int QuestionId { get; set; }
        public int? SyllabusId { get; set; }         // optional linkage
        public int? MatrixId { get; set; }           // optional
        public string? QuestionText { get; set; }
        public QuestionType QuestionType { get; set; } = QuestionType.MCQ;
        public string? OptionsJson { get; set; }     // store options as JSON string
        public string? Answers { get; set; }         // text (correct answers)
        public int? Marks { get; set; }
    }
}
