using Domain.Enum;

namespace Domain.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public int UserId { get; set; }              // FK to Users.UserId (in Auth DB)
        public string? Name { get; set; }
        public int? ClassId { get; set; }            // optional
        public DateTime? EnrollmentDate { get; set; }
        public StudentStatus Status { get; set; } = StudentStatus.Active;
    }
}
