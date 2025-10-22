using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AiDbContext : DbContext
    {
        public AiDbContext(DbContextOptions<AiDbContext> opts) : base(opts) { }

        public DbSet<AIConfig> AIConfigs => Set<AIConfig>();
        public DbSet<AICallLog> AICallLogs => Set<AICallLog>();
        public DbSet<AIHistoryChat> AIHistoryChats => Set<AIHistoryChat>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<AIConfig>(e =>
            {
                e.ToTable("ai_config");
                e.HasKey(x => x.ConfigId);
                e.Property(x => x.ModelName).HasMaxLength(100);
                e.Property(x => x.Temperature).HasColumnType("decimal(3,2)");
                e.Property(x => x.SettingsJson).HasColumnType("nvarchar(max)");
            });

            b.Entity<AICallLog>(e =>
            {
                e.ToTable("ai_call_log");
                e.HasKey(x => x.LogId);
                e.Property(x => x.RequestText);
                e.Property(x => x.ResponseText);
            });

            b.Entity<AIHistoryChat>(e =>
            {
                e.ToTable("ai_history_chat");
                e.HasKey(x => x.ChatId);
                e.Property(x => x.Message);
            });

            // FK inside Ai DB: AICallLog.ConfigId -> AIConfig.ConfigId
            b.Entity<AICallLog>().HasOne<AIConfig>().WithMany().HasForeignKey(x => x.ConfigId).OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(b);
        }
    }
}
