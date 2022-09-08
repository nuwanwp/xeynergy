using Bourque.EMAILQueue.Data.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bourque.EMAILQueue.EntityFramework.Context
{
    public class EmailQueueDbContext : DbContext
    {
        protected ILogger<EmailQueueDbContext> Logger;

        public EmailQueueDbContext()
        {

        }

        public EmailQueueDbContext(DbContextOptions<EmailQueueDbContext> options, ILogger<EmailQueueDbContext> logger) : base(options)
        {
            Logger = logger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=;Database=EmailJob;Integrated Security=True;").
                LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailQueueRecord>()
                .HasMany(c => c.Attachements)
                .WithOne(e => e.QueueRecord);
        }

        public virtual DbSet<EmailQueueRecord> EmailQueueRecords { get; set; }

        public virtual DbSet<EmailAttachement> EmailAttachements { get; set; }

        public virtual DbSet<EmailServer> EmailServers { get; set; }
    }
}
