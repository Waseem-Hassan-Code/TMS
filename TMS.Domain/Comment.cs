using Domain.Entities.Identity;

namespace TMS.Domain
{
    public class Comment
    {
        public Guid CommentId { get; set; } = Guid.NewGuid();
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        // Foreign Keys
        public Guid TaskId { get; set; }

        public Tasks Task { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}