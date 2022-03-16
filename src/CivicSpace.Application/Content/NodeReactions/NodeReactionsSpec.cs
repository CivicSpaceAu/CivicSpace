using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;

namespace CivicSpace.Application.Content.Nodes;

public class NodeReactionsSpec : Specification<NodeReaction, IEnumerable<NodeReaction>>, ISingleResultSpecification
{
    public NodeReactionsSpec(Guid nodeId) =>
        Query.Where(p => p.NodeId == nodeId);
}
