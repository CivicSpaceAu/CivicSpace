using System.ComponentModel.DataAnnotations;

namespace CivicSpace.Core.Entities
{
    public abstract class Entity
    {
        [Key]
        public string Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
