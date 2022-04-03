﻿using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;
using FSH.WebApi.Application.Common.Exceptions;
using FSH.WebApi.Application.Common.Models;
using FSH.WebApi.Application.Common.Persistence;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CivicSpace.Application.Content.Nodes;

public class GetNodeVotesRequest : PaginationFilter, IRequest<PaginationResponse<NodeVoteDto>>
{
    public Guid NodeId { get; set; }

    public GetNodeVotesRequest(Guid id) => NodeId = id;
}

public class GetNodeVotesRequestHandler : IRequestHandler<GetNodeVotesRequest, PaginationResponse<NodeVoteDto>>
{
    private readonly IRepository<NodeVote> _repository;
    private readonly IStringLocalizer<GetNodeRequestHandler> _localizer;

    public GetNodeVotesRequestHandler(IRepository<NodeVote> repository, IStringLocalizer<GetNodeRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<PaginationResponse<NodeVoteDto>> Handle(GetNodeVotesRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<NodeVote, PaginationResponse<NodeVoteDto>>)new NodeVotesSpec(request.NodeId), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["nodeVote.notfound"], request.NodeId));
}