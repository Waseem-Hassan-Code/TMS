using System.Net.Mail;

namespace TMS.Domain
{
    public class Task
    {
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }

        // Foreign Key
        public Guid TeamId { get; set; }

        public Team Team { get; set; }

        // Relationships
        public ICollection<Assignment> Assignments { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
        public ICollection<TaskHistory> TaskHistories { get; set; }
    }
}