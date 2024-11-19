using Microsoft.AspNetCore.Identity;
using TMS.Domain;

namespace Domain.Entities.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public ICollection<Assignment> Assignments { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Notification> Notifications { get; set; }
    public ICollection<TaskHistory> TaskHistories { get; set; }
}