using Domain.Entities.Identity;

namespace TMS.Domain
{
    public class Assignment
    {
        public Guid AssignmentId { get; set; } = Guid.NewGuid();
        public DateTime AssignedDate { get; set; }

        // Foreign Keys
        public Guid TaskId { get; set; }

        public Tasks Task { get; set; }

        public Guid AssignedToUserId { get; set; }
        public ApplicationUser AssignedTo { get; set; }

        public Guid AssignedByUserId { get; set; }
        public ApplicationUser AssignedBy { get; set; }
    }
}