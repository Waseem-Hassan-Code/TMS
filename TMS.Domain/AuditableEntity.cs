using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Domain
{
    public class AuditableEntity : BaseEntity
    {
        public virtual Guid CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual Guid? LastModifiedBy { get; set; }
        public virtual DateTime? LastModifiedDate { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}
