using Domain.Entities.Identity;

namespace TMS.Domain
{
    public class TaskHistory
    {
        public Guid HistoryId { get; set; } = Guid.NewGuid();
        public string Action { get; set; }
        public DateTime PerformedDate { get; set; }

        // Foreign Keys
        public Guid TaskId { get; set; }
        public Task Task { get; set; }

        public Guid PerformedByUserId { get; set; }
        public ApplicationUser PerformedBy { get; set; }
    }

}