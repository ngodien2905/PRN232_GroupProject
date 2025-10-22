using Domain.Enum;

namespace Domain.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }           // teachers.teacher_id
        public int UserId { get; set; }              // FK to Users.UserId (in Auth DB)
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public TeacherStatus Status { get; set; } = TeacherStatus.Active;
    }
}
