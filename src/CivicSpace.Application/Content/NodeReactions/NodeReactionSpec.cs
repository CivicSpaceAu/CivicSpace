using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;

namespace CivicSpace.Application.Content.Nodes;

public class NodeReactionSpec : Specification<NodeReaction, NodeReactionDto>, ISingleResultSpecification
{
    public NodeReactionSpec(Guid nodeId, Guid createdBy) =>
        Query.Where(nr => nr.NodeId == nodeId && nr.CreatedBy == createdBy);
}

