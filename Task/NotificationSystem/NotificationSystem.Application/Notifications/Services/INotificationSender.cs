using NotificationSystem.Domain.Entities;
using NotificationSystem.Domain.Enums;

namespace NotificationSystem.Application.Notifications.Services
{
    public interface INotificationSender
    {
        NotificationType Type { get; }
        Task SendAsync(Notification notification);
    }
}
