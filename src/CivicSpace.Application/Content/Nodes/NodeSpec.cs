using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;

namespace CivicSpace.Application.Content.Nodes;

public class NodeSpec : Specification<Node>, ISingleResultSpecification
{
    public NodeSpec(Guid id) =>
        Query.Where(n => n.Id == id)
        .Include(n => n.Tags);
}

