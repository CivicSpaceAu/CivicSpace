using FSH.WebApi.Application.Common.Interfaces;

namespace CivicSpace.Application.Content.Nodes;

public class NodeLinkDto : IDto
{
    public Guid Id { get; set; }
    public Guid FromNodeId { get; set; } = default!;
    public Guid ToNodeId { get; set; } = default!;
    public string? Type { get; set; }
    public int? Weight { get; set; }
}
