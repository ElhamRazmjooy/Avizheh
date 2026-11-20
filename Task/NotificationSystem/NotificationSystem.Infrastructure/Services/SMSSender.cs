using NotificationSystem.Application.Notifications.Services;
using NotificationSystem.Domain.Entities;
using NotificationSystem.Domain.Enums;

namespace NotificationSystem.Infrastructure.Services
{
    public class SMSSender : INotificationSender
    {
        public NotificationType Type => throw new NotImplementedException();

        public Task SendAsync(Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
