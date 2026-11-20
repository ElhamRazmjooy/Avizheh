using NotificationSystem.Application.Notifications.Commands;
using NotificationSystem.Domain.Entities;
using NotificationSystem.Domain.Repositories;

namespace NotificationSystem.Application.Notifications.Handlers
{
    public class CreateNotificationHandler(INotificationRepository repository)
    {
        public async Task<Guid> Handle(CreateNotificationCommand command)
        {
            var notification = new Notification(command.Title, command.Message, command.Receiver, command.Type);
            await repository.AddAsync(notification);
            return notification.Id;
        }
    }
}