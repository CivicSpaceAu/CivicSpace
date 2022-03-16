using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;

namespace CivicSpace.Application.Content.Nodes;

public class NodeBySlugSpec : Specification<Node>, ISingleResultSpecification
{
    public NodeBySlugSpec(string slug) =>
        Query.Where(n => n.Slug == slug)
        .Include(n => n.Tags);
}

