using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ExamDbContext : DbContext
    {
        public ExamDbContext(DbContextOptions<ExamDbContext> opts) : base(opts) { }

        public DbSet<ExamAttempt> ExamAttempts => Set<ExamAttempt>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<ExamAttempt>(e =>
            {
                e.ToTable("exam_attempts");
                e.HasKey(x => x.AttemptId);
                e.Property(x => x.Score).HasColumnType("decimal(5,2)");
                e.Property(x => x.Status).HasConversion<string>().HasMaxLength(30);
            });

            base.OnModelCreating(b);
        }
    }
}
