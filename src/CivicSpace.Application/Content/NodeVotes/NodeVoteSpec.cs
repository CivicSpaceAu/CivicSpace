using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;

namespace CivicSpace.Application.Content.Nodes;

public class NodeVoteSpec : Specification<NodeVote, NodeVoteDto>, ISingleResultSpecification
{
    public NodeVoteSpec(Guid nodeId, Guid createdBy) =>
        Query.Where(nv => nv.NodeId == nodeId && nv.CreatedBy == createdBy);
}

