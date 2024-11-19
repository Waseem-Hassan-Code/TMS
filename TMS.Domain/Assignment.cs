using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Domain
{
    public class Assignment
    {
        public Guid AssignmentId { get; set; } = Guid.NewGuid();
        public DateTime AssignedDate { get; set; }

        // Foreign Keys
        public Guid TaskId { get; set; }
        public Task Task { get; set; }

        public Guid AssignedToUserId { get; set; }
        public User AssignedTo { get; set; }

        public Guid AssignedByUserId { get; set; }
        public User AssignedBy { get; set; }
    }
}
