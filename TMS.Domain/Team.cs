using Domain.Entities.Identity;

namespace TMS.Domain
{
    public class Team
    {
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
        public string Description { get; set; }

        // Relationships
        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}