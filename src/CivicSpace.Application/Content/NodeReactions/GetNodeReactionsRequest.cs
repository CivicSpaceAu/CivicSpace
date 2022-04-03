using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;
using FSH.WebApi.Application.Common.Exceptions;
using FSH.WebApi.Application.Common.Models;
using FSH.WebApi.Application.Common.Persistence;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CivicSpace.Application.Content.Nodes;

public class GetNodeReactionsRequest : IRequest<PaginationResponse<NodeReactionDto>>
{
    public Guid NodeId { get; set; }

    public GetNodeReactionsRequest(Guid nodeId) => NodeId = nodeId;
}

public class GetNodeReactionRequestHandler : IRequestHandler<GetNodeReactionsRequest, PaginationResponse<NodeReactionDto>>
{
    private readonly IRepository<NodeReaction> _repository;
    private readonly IStringLocalizer<GetNodeReactionRequestHandler> _localizer;

    public GetNodeReactionRequestHandler(IRepository<NodeReaction> repository, IStringLocalizer<GetNodeReactionRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<PaginationResponse<NodeReactionDto>> Handle(GetNodeReactionsRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<NodeReaction, PaginationResponse<NodeReactionDto>>)new NodeReactionsSpec(request.NodeId), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["nodeReaction.notfound"], request.NodeId));
}