using FSH.WebApi.Domain.Common.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Domain.Entities.Content
{
    public class NodeReaction : AuditableEntity
    {
        [ForeignKey("Node")]
        public string NodeId { get; set; }
        public virtual Node? Node { get; set; }
        public string ReactionType { get; set; }

        public NodeReaction(string nodeId, string reactionType)
        {
            NodeId = nodeId;
            ReactionType = reactionType;
        }
    }
}
