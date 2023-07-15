namespace CivicSpace.Core.Entities
{
    public abstract class AuditableEntity : Entity
    {
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; private set; }

        protected AuditableEntity() : base()
        {
            CreatedDate = DateTime.UtcNow;
        }
    }
}
