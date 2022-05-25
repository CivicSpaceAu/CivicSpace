﻿using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;
using FSH.WebApi.Application.Common.Exceptions;
using FSH.WebApi.Application.Common.Models;
using FSH.WebApi.Application.Common.Persistence;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CivicSpace.Application.Content.Nodes;

public class GetToNodeLinksRequest : PaginationFilter, IRequest<PaginationResponse<NodeLinkDto>>
{
    public Guid FromNodeId { get; set; }
    public string Type { get; set; }

    public GetToNodeLinksRequest(Guid fromNodeId, string type)
    {
        FromNodeId = fromNodeId;
        Type = type;
    }
}

public class ToNodeLinksSpec : Specification<NodeLink, PaginationResponse<NodeLinkDto>>, ISingleResultSpecification
{
    public ToNodeLinksSpec(Guid nodeId, string type) =>
        Query.Where(nl => nl.NodeId == nodeId && (string.IsNullOrEmpty(type) || nl.Type == type));
}

public class GetToNodeLinksRequestHandler : IRequestHandler<GetToNodeLinksRequest, PaginationResponse<NodeLinkDto>>
{
    private readonly IRepository<NodeLink> _repository;
    private readonly IStringLocalizer<GetFromNodeLinksRequestHandler> _localizer;

    public GetToNodeLinksRequestHandler(IRepository<NodeLink> repository, IStringLocalizer<GetFromNodeLinksRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<PaginationResponse<NodeLinkDto>> Handle(GetToNodeLinksRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<NodeLink, PaginationResponse<NodeLinkDto>>)new ToNodeLinksSpec(request.FromNodeId, request.Type), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["nodeLink.notfound"], request.FromNodeId));
}