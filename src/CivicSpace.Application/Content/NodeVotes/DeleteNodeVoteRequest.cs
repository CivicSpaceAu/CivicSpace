using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;
using FSH.WebApi.Application.Common.Exceptions;
using FSH.WebApi.Application.Common.Persistence;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CivicSpace.Application.Content.Nodes;

public class DeleteNodeVoteRequest : IRequest<Guid>
{
    public Guid NodeId { get; set; }
    public Guid CreatedBy { get; set; }

    public DeleteNodeVoteRequest(Guid id, Guid createdBy)
    {
        NodeId = id;
        CreatedBy = createdBy;
    }
}

public class DeleteNodeVoteRequestHandler : IRequestHandler<DeleteNodeVoteRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<NodeVote> _repository;
    private readonly IStringLocalizer<DeleteNodeRequestHandler> _localizer;

    public DeleteNodeVoteRequestHandler(IRepositoryWithEvents<NodeVote> repository, IStringLocalizer<DeleteNodeRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(DeleteNodeVoteRequest request, CancellationToken cancellationToken)
    {
        var nodeVote = await _repository.GetBySpecAsync(new NodeVoteSpec(request.NodeId, request.CreatedBy));
        _ = nodeVote ?? throw new NotFoundException(_localizer["nodeVote.notfound"]);
        await _repository.DeleteAsync(nodeVote, cancellationToken);
        return nodeVote.Id;
    }
}
