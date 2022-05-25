using FSH.WebApi.Domain.Common.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Domain.Entities.Content
{
    public class NodeLink : AuditableEntity, IAggregateRoot
    {
        [ForeignKey("Node")]
        public Guid NodeId { get; set; }
        [ForeignKey("LinkedNode")]
        public Guid LinkedNodeId { get; set; }
        public virtual Node? Node { get; set; }
        public virtual Node? LinkedNode { get; set; }
        public string? Type { get; set; }
        public int? Weight { get; set; }

        public NodeLink(Guid nodeId, Guid linkedNodeId, string? type, int? weight)
        {
            NodeId = nodeId;
            LinkedNodeId = linkedNodeId;
            Type = type;
            Weight = weight;
        }

        public NodeLink Update(string? type, int? weight)
        {
            if (type is not null && Type?.Equals(type) is not true) Type = type;
            if (weight is not null && Weight?.Equals(weight) is not true) Weight = weight;
            return this;
        }
    }
}
