using System.ComponentModel.DataAnnotations;

namespace CivicSpace.Core.Content
{
    public abstract class AuditableEntity
    {
        [Key]
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; private set; }

        protected AuditableEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedOn = DateTime.UtcNow;
        }
    }
}
