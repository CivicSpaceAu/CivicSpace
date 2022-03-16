using FSH.WebApi.Domain.Common.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Domain.Entities.Content
{
    public class NodeReaction : AuditableEntity, IAggregateRoot
    {
        [ForeignKey("Node")]
        public Guid NodeId { get; set; }
        public virtual Node? Node { get; set; }
        public string Type { get; set; }

        public NodeReaction(Guid nodeId, string reactionType)
        {
            NodeId = nodeId;
            Type = reactionType;
        }

        public NodeReaction Update(string type)
        {
            if (Type.Equals(type) is not true) Type = type;
            return this;
        }
    }
}
