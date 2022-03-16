using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;

namespace CivicSpace.Application.Content.Nodes;

public class NodeVotesSpec : Specification<NodeVote>
{
    public NodeVotesSpec(Guid nodeId) =>
        Query.Where(nv => nv.NodeId == nodeId);
}

