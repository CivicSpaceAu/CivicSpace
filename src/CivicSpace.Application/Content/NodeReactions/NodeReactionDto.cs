using FSH.WebApi.Application.Common.Interfaces;

namespace CivicSpace.Application.Content.Nodes;

public class NodeReactionDto : IDto
{
    public Guid Id { get; set; }
    public Guid NodeId { get; set; } = default!;
    public string ReactionType { get; set; } = default!;
}
