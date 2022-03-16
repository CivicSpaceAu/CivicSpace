﻿using FSH.WebApi.Domain.Common.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Domain.Entities.Content
{
    // https://www.reddit.com/r/programming/comments/bg030/upvotedownvote_database_structure/
    public class NodeVote : AuditableEntity, IAggregateRoot
    {
        [ForeignKey("Node")]
        public Guid NodeId { get; set; }
        public Node? Node { get; set; }
        [Required]
        public short Score { get; set; }

        public NodeVote(Guid nodeId, short score)
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
