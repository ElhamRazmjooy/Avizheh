using NotificationSystem.Domain.Entities;

namespace NotificationSystem.Domain.Repositories
{
    public interface INotificationRepository
    {
        Task AddAsync(Notification notification);
        Task<Notification> GetByIdAsync(Guid id);
        Task UpdateAsync(Notification notification);
        Task<IEnumerable<Notification>> GetAllAsync();
    }
}
