using FSH.WebApi.Domain.Common.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Domain.Entities.Content
{
    // https://www.reddit.com/r/programming/comments/bg030/upvotedownvote_database_structure/
    public class NodeTag
    {
        [ForeignKey("Node")]
        public Guid NodeId { get; set; }
        public Node? Node { get; set; }
        [Required]
        public string Tag { get; set; }

        public NodeTag(Guid nodeId, string tag)
        {
            NodeId = nodeId;
            Tag = tag;
        }
    }
}
