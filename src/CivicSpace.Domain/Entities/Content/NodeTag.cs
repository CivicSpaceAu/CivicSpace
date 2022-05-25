using FSH.WebApi.Domain.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Domain.Entities.Content
{
    public class NodeTag
    {
        public Guid Id { get; protected set; } = default!;
        public Guid NodeId { get; set; } = default!;
        public Node Node { get; set; } = default!;
        public string Tag { get; set; }

        public NodeTag(Guid nodeId, string tag)
        {
            NodeId = nodeId;
            Tag = tag;
        }
    }
}
