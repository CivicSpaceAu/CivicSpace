using FSH.WebApi.Domain.Common.Contracts;

namespace CivicSpace.Domain.Entities.User
{
    public class Badge : AuditableEntity
    {
        public string Name { get; set; } = default!;
    }
}
