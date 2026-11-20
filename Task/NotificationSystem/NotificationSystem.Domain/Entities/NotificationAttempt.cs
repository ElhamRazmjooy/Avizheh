namespace NotificationSystem.Domain.Entities
{
    public class NotificationAttempt
    {
        public Guid Id { get; private set; }
        public Guid NotificationId { get; private set; }
        public DateTime AttemptDate { get; private set; }
        public bool IsSuccessful { get; private set; }
        public string ErrorMessage { get; private set; }
        public NotificationAttempt(Guid notificationId, bool isSuccessful, string errorMessage = null)
        {
            Id = Guid.NewGuid();
            NotificationId=notificationId;
            AttemptDate = DateTime.Now;
            IsSuccessful=isSuccessful;
            ErrorMessage=errorMessage;
        }
    }
}
