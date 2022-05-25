using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;

namespace CivicSpace.Application.Content.Nodes;

public class NodeLinkSpec : Specification<NodeLink, NodeLink>, ISingleResultSpecification
{
    public NodeLinkSpec(Guid nodeId, Guid linkedNodeId) =>
        Query.Where(nl => nl.NodeId == nodeId && nl.LinkedNodeId == linkedNodeId);
}
