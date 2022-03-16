using FSH.WebApi.Application.Common.Interfaces;

namespace CivicSpace.Application.Content.Nodes;

public class NodeVoteDto : IDto
{
    public Guid Id { get; set; }
    public Guid NodeId { get; set; } = default!;
    public int Score { get; set; } = default!;
}
