using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Core.Content
{
    public class NodeCustomField : ModifiableAuditableEntity
    {
        [ForeignKey("Node")]
        public string NodeId { get; set; } = string.Empty;
        public Node Node { get; set; } = default!;
        [Required]
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

        public NodeCustomField(string nodeId, string key, string value) : base()
        {
            NodeId = nodeId;
            Key = key;
            Value = value;
        }
    }
}
