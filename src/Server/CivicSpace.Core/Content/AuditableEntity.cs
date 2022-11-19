namespace CivicSpace.Core.Content
{
    public abstract class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; private set; }

        protected AuditableEntity()
        {
            CreatedOn = DateTime.UtcNow;
        }
    }
}
