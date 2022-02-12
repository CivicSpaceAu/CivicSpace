using FSH.WebApi.Domain.Common.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Domain.Entities.Content
{
    // https://www.reddit.com/r/programming/comments/bg030/upvotedownvote_database_structure/
    public class NodeVote : AuditableEntity<string>
    {
        [ForeignKey("Node")]
        public string NodeId { get; set; } = Guid.NewGuid().ToString();
        public Node Node { get; set; }
        [Required]
        public short Score { get; set; }
    }
}
