using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ContentDbContext : DbContext
    {
        public ContentDbContext(DbContextOptions<ContentDbContext> opts) : base(opts) { }

        public DbSet<Class> Classes => Set<Class>();
        public DbSet<Subject> Subjects => Set<Subject>();
        public DbSet<Syllabus> Syllabi => Set<Syllabus>();
        public DbSet<ExamMatrix> ExamMatrices => Set<ExamMatrix>();
        public DbSet<ExamQuestion> ExamQuestions => Set<ExamQuestion>();
        public DbSet<Activity> Activities => Set<Activity>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<Class>(e =>
            {
                e.ToTable("classes");
                e.HasKey(x => x.ClassId);
                e.Property(x => x.Name).HasMaxLength(150);
                e.Property(x => x.Schedule).HasMaxLength(100);
            });

            b.Entity<Subject>(e =>
            {
                e.ToTable("subjects");
                e.HasKey(x => x.SubjectId);
                e.Property(x => x.Title).HasMaxLength(150);
                e.Property(x => x.Description);
            });

            b.Entity<Syllabus>(e =>
            {
                e.ToTable("syllabus");
                e.HasKey(x => x.SyllabusId);
                e.Property(x => x.Title).HasMaxLength(150);
                e.Property(x => x.Url);
            });

            b.Entity<ExamMatrix>(e =>
            {
                e.ToTable("exam_matrix");
                e.HasKey(x => x.MatrixId);
                e.Property(x => x.Title).HasMaxLength(150);
            });

            b.Entity<ExamQuestion>(e =>
            {
                e.ToTable("exam_questions");
                e.HasKey(x => x.QuestionId);
                e.Property(x => x.QuestionText);
                e.Property(x => x.QuestionType).HasConversion<string>().HasMaxLength(30);
                e.Property(x => x.OptionsJson).HasColumnType("nvarchar(max)");
                e.Property(x => x.Answers);
                e.Property(x => x.Marks);
            });

            b.Entity<Activity>(e =>
            {
                e.ToTable("activities");
                e.HasKey(x => x.ActivityId);
                e.Property(x => x.Title).HasMaxLength(150);
            });

            base.OnModelCreating(b);
        }
    }
}
