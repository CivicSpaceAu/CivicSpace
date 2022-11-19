using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Core.Content
{
    public class NodeReaction : AuditableEntity
    {
        [ForeignKey("Node")]
        public string NodeId { get; set; }
        public virtual Node? Node { get; set; }
        public string Type { get; set; }

        public NodeReaction(string nodeId, string type) : base()
        {
            NodeId = nodeId;
            Type = type;
        }

        public NodeReaction Update(string type)
        {
            if (Type.Equals(type) is not true) Type = type;
            return this;
        }
    }
}
