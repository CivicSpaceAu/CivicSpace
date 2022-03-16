using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;
using FSH.WebApi.Application.Common.Exceptions;
using FSH.WebApi.Application.Common.Persistence;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CivicSpace.Application.Content.Nodes;

public class DeleteNodeLinkRequest : IRequest<Guid>
{
    public Guid FromNodeId { get; set; }
    public Guid ToNodeId { get; set; }

    public DeleteNodeLinkRequest(Guid fromNodeId, Guid toNodeId)
    {
        FromNodeId = fromNodeId;
        ToNodeId = toNodeId;
    }
}

public class DeleteNodeLinkRequestHandler : IRequestHandler<DeleteNodeLinkRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<NodeLink> _repository;
    private readonly IStringLocalizer<DeleteNodeLinkRequestHandler> _localizer;

    public DeleteNodeLinkRequestHandler(IRepositoryWithEvents<NodeLink> nodeLinkRepo, IStringLocalizer<DeleteNodeLinkRequestHandler> localizer) =>
        (_repository, _localizer) = (nodeLinkRepo, localizer);

    public async Task<Guid> Handle(DeleteNodeLinkRequest request, CancellationToken cancellationToken)
    {
        var nodeLink = await _repository.GetBySpecAsync((ISpecification<NodeLink, NodeLink>)
            new NodeLinkSpec(request.FromNodeId, request.ToNodeId));

        _ = nodeLink ?? throw new NotFoundException(_localizer["nodeLink.notfound"]);

        await _repository.DeleteAsync(nodeLink, cancellationToken);

        return nodeLink.Id;
    }
}
