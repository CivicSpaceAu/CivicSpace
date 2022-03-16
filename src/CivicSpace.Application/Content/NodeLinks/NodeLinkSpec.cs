using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;

namespace CivicSpace.Application.Content.Nodes;

public class NodeLinkSpec : Specification<NodeLink, NodeLink>, ISingleResultSpecification
{
    public NodeLinkSpec(Guid fromNodeId, Guid toNodeId) =>
        Query.Where(nl => nl.FromNodeId == fromNodeId && nl.ToNodeId == toNodeId);
}
