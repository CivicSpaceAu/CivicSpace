using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Core.Content
{
    public class NodeTag : AuditableEntity
    {
        [ForeignKey("Node")]
        public string NodeId { get; set; } = default!;
        public Node Node { get; set; } = default!;
        public string Tag { get; set; }

        public NodeTag(string nodeId, string tag) : base()
        {
            NodeId = nodeId;
            Tag = tag;
        }
    }
}
