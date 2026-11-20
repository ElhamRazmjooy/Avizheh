using NotificationSystem.Domain.Enums;

namespace NotificationSystem.Domain.Entities
{
    public class Notification
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Message { get; private set; }
        public string Receiver { get; private set; }
        public NotificationType Type { get; private set; }
        public NotificationStatus Status { get; private set; }
        public int RetryCount { get; private set; }
        public ICollection<NotificationAttempt> Attempts { get; private set; }
        public Notification(string title, string message, string receiver, NotificationType type)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException( "Title is required.",nameof(title));
                   
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message Is Required!", nameof(message));

            if (string.IsNullOrWhiteSpace(receiver))
                throw new ArgumentException("Reciver Is Required!", nameof(receiver));

            if (!Enum.IsDefined(typeof(NotificationType), type))
                throw new ArgumentException("Invalid notification type.");

            if (type == NotificationType.Email && !System.Text.RegularExpressions.Regex.IsMatch
                (receiver, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Invalid Email Address");

            if (type == NotificationType.SMS && !System.Text.RegularExpressions.Regex.IsMatch(receiver, @"^09\d{9}$"))
                throw new ArgumentException("Invalid PhoneNumber");

            Id = Guid.NewGuid();
            Title=title;
            Message=message;
            Receiver=receiver;
            Type=type;
            Status = NotificationStatus.Pending;
            RetryCount = 0;
            Attempts = new List<NotificationAttempt>();
        }
        public void MarkAsSent()
        {
            if (Status != NotificationStatus.Pending)
                throw new InvalidOperationException("Only Pending notifications can be marked as Sent.");

            Status = NotificationStatus.Sent;
        }
        public void MarkAsFailed()
        {
            if (Status != NotificationStatus.Pending)
                throw new InvalidOperationException("Only Pending notifications can be marked as Failed.");

            Status =NotificationStatus.Failed;
        }
        public void IncrementRetry()
        {
            RetryCount++;
        }
        public void AddAttempt(bool isSuccessful, string errorMessage = null)
        {
            var attempt = new NotificationAttempt(Id, isSuccessful, errorMessage);

            Attempts.Add(attempt);
            RetryCount++;

            if (isSuccessful) MarkAsSent();
            else if (RetryCount >= 3) MarkAsFailed();
        }
    }
}
