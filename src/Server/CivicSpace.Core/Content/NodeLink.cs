using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Core.Content
{
    public class NodeLink
    {
        [ForeignKey("Node")]
        public string NodeId { get; set; }
        [ForeignKey("LinkedNode")]
        public string LinkedNodeId { get; set; }
        public virtual Node? Node { get; set; }
        public virtual Node? LinkedNode { get; set; }
        public string Type { get; set; }
        public int Weight { get; set; }

        public NodeLink(string nodeId, string linkedNodeId, string type, int? weight)
        {
            NodeId = nodeId;
            LinkedNodeId = linkedNodeId;
            Type = type;
            Weight = weight.Value;
        }

        public NodeLink Update(string type, int? weight)
        {
            if (type is not null && Type?.Equals(type) is not true) Type = type;
            if (weight is not null && Weight.Equals(weight) is not true) Weight = weight.Value;
            return this;
        }
    }
}
