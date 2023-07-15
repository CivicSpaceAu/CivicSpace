namespace CivicSpace.Core.Entities
{
    public class ModifiableEntity : AuditableEntity
    {
        public string LastModifiedBy { get; set; } = string.Empty;
        public DateTime? LastModifiedDate { get; set; }
        protected ModifiableEntity() : base()
        {
            LastModifiedDate = DateTime.UtcNow;
        }
    }
}
