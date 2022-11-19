using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Core.Content
{
    public class NodeCustomField : ModifiableAuditableEntity
    {
        [Key]
        public string Id { get; protected set; } = default!;
        [ForeignKey("Node")]
        public string NodeId { get; set; } = default!;
        public Node Node { get; set; } = default!;
        public string Key { get; set; }
        public string Value { get; set; }

        public NodeCustomField(string nodeId, string key, string value) : base()
        {
            NodeId = nodeId;
            Key = key;
            Value = value;
        }
    }
}
