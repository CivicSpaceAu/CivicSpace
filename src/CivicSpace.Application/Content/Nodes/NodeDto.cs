using FSH.WebApi.Application.Common.Interfaces;

namespace CivicSpace.Application.Content.Nodes;

public class NodeDto : IDto
{
    public Guid Id { get; set; }
    public string Module { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string? Content { get; set; }
    public string Status { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string Path { get; set; } = default!;
    public string ParentId { get; set; } = default!;
}
