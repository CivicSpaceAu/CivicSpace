using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Core.Content
{
    public class NodeCustomField
    {
        [Key]
        public Guid Id { get; protected set; } = default!;
        [ForeignKey("Node")]
        public Guid NodeId { get; set; } = default!;
        public Node Node { get; set; } = default!;
        public string Key { get; set; }
        public string Value { get; set; }

        public NodeCustomField(Guid nodeId, string key, string value)
        {
            NodeId = nodeId;
            Key = key;
            Value = value;
        }
    }
}
