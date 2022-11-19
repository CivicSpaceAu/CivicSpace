using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivicSpace.Core.Content
{
    public class ModifiableAuditableEntity : AuditableEntity
    {
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        protected ModifiableAuditableEntity() : base()
        {
            LastModifiedOn = DateTime.UtcNow;
        }
    }
}
