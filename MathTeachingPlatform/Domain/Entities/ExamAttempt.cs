using Domain.Enum;

namespace Domain.Entities
{
    public class ExamAttempt
    {
        public int AttemptId { get; set; }           // attempt_id
        public int StudentId { get; set; }           // student id (Auth DB)
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? Score { get; set; }          // decimal(5,2)
        public int AttemptNumber { get; set; }
        public ExamAttemptStatus Status { get; set; } = ExamAttemptStatus.InProgress;
    }
}
