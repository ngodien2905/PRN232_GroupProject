using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> opts) : base(opts) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Payment> Payments => Set<Payment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b =>
            {
                b.ToTable("users");
                b.HasKey(x => x.UserId);
                b.Property(x => x.Username).HasMaxLength(100).IsRequired();
                b.HasIndex(x => x.Username).IsUnique();
                b.Property(x => x.PasswordHash).HasMaxLength(255).IsRequired();
                b.Property(x => x.Role).HasConversion<string>().HasMaxLength(50);
                b.Property(x => x.Email).HasMaxLength(150);
            });

            modelBuilder.Entity<Teacher>(b =>
            {
                b.ToTable("teachers");
                b.HasKey(x => x.TeacherId);
                b.Property(x => x.Name).HasMaxLength(150);
                b.Property(x => x.Status).HasConversion<string>().HasMaxLength(20);
                // don't add FK constraint to users across DBs; link by Id only
            });

            modelBuilder.Entity<Student>(b =>
            {
                b.ToTable("students");
                b.HasKey(x => x.StudentId);
                b.Property(x => x.Name).HasMaxLength(150);
                b.Property(x => x.Status).HasConversion<string>().HasMaxLength(20);
            });

            modelBuilder.Entity<Payment>(b =>
            {
                b.ToTable("payments");
                b.HasKey(x => x.PaymentId);
                b.Property(x => x.Amount).HasColumnType("decimal(10,2)");
                b.Property(x => x.Method).HasConversion<string>().HasMaxLength(20);
                b.Property(x => x.Status).HasConversion<string>().HasMaxLength(20);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
