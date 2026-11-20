using NotificationSystem.Domain.Enums;

namespace NotificationSystem.Application.Notifications.Commands
{
    public class CreateNotificationCommand
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Receiver { get; set; }
        public NotificationType Type { get; set; }
    }
}
