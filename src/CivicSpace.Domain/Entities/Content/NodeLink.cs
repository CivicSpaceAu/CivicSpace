using FSH.WebApi.Domain.Common.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Domain.Entities.Content
{
    public class NodeLink : AuditableEntity, IAggregateRoot
    {
        [ForeignKey("FromNode")]
        public Guid FromNodeId { get; set; }
        [ForeignKey("ToNode")]
        public Guid ToNodeId { get; set; }
        public virtual Node? FromNode { get; set; }
        public virtual Node? ToNode { get; set; }
        public string? Type { get; set; }
        public int? Weight { get; set; }

        public NodeLink(Guid fromNodeId, Guid toNodeId, string? type, int? weight)
        {
            FromNodeId = fromNodeId;
            ToNodeId = toNodeId;
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
