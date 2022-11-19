using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Core.Content
{
    // https://www.reddit.com/r/programming/comments/bg030/upvotedownvote_database_structure/
    public class NodeVote : AuditableEntity
    {
        [ForeignKey("Node")]
        public string NodeId { get; set; }
        public Node? Node { get; set; }
        [Required]
        public short Score { get; set; }

        public NodeVote(string nodeId, short score) : base()
        {
            NodeId = nodeId;
            Score = score;
        }

        public NodeVote Update(short score)
        {
            Score = score;
            return this;
        }
    }
}
