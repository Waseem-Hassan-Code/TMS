using Domain.Entities.Identity;

namespace TMS.Domain
{
    public class Notification
    {
        public Guid NotificationId { get; set; } = Guid.NewGuid();
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }

        // Foreign Key
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}