using Microsoft.EntityFrameworkCore;
using NotificationSystem.Domain.Entities;
using NotificationSystem.Domain.Repositories;

namespace NotificationSystem.Infrastructure.Persistence
{
    public class NotificationRepository(NotificationDbContext context) : INotificationRepository
    {
        public async Task AddAsync(Notification notification)
        {
            context.Notifications.Add(notification);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Notification>> GetAllAsync() => await context.Notifications.Include(x => x.Attempts).ToListAsync();
        public async Task<Notification> GetByIdAsync(Guid id) => await context.Notifications.Include(x => x.Attempts)
            .FirstOrDefaultAsync(x => x.Id == id);
        public async Task UpdateAsync(Notification notification)
        {
            context.Entry(notification).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
