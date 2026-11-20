using Microsoft.EntityFrameworkCore;
using NotificationSystem.Domain.Entities;

namespace NotificationSystem.Infrastructure.Persistence
{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
        {
        }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationAttempt> NotificationAttempts { get; set; }
    }
}
