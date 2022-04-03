using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;
using FSH.WebApi.Application.Common.Exceptions;
using FSH.WebApi.Application.Common.Persistence;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CivicSpace.Application.Content.Nodes;

public class DeleteNodeReactionRequest : IRequest<Guid>
{
    public Guid NodeId { get; set; }
    public Guid CreatedBy { get; set; }

    public DeleteNodeReactionRequest(Guid nodeId) => NodeId = nodeId;
}

public class DeleteNodeReactionRequestHandler : IRequestHandler<DeleteNodeReactionRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<NodeReaction> _repository;
    private readonly IStringLocalizer<DeleteNodeRequestHandler> _localizer;

    public DeleteNodeReactionRequestHandler(IRepositoryWithEvents<NodeReaction> nodeRepo, IStringLocalizer<DeleteNodeRequestHandler> localizer) =>
        (_repository, _localizer) = (nodeRepo, localizer);

    public async Task<Guid> Handle(DeleteNodeReactionRequest request, CancellationToken cancellationToken)
    {
        var nodeReaction = await _repository.GetBySpecAsync(new NodeReactionSpec(request.NodeId, request.CreatedBy));

        _ = nodeReaction ?? throw new NotFoundException(_localizer["nodeReaction.notfound"]);

        await _repository.DeleteAsync(nodeReaction, cancellationToken);

        return nodeReaction.Id;
    }
}
