using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;
using FSH.WebApi.Application.Common.Exceptions;
using FSH.WebApi.Application.Common.Models;
using FSH.WebApi.Application.Common.Persistence;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CivicSpace.Application.Content.Nodes;

public class GetFromNodeLinksRequest : PaginationFilter, IRequest<PaginationResponse<NodeLinkDto>>
{
    public Guid LinkedNodeId { get; set; }
    public string Type { get; set; }

    public GetFromNodeLinksRequest(Guid linkedNodeId, string type)
    {
        LinkedNodeId = linkedNodeId;
        Type = type;
    }
}

public class FromNodeLinksSpec : Specification<NodeLink, PaginationResponse<NodeLinkDto>>, ISingleResultSpecification
{
    public FromNodeLinksSpec(Guid linkedNodeId, string type) =>
        Query.Where(nl => nl.LinkedNodeId == linkedNodeId && (string.IsNullOrEmpty(type) || nl.Type == type));
}

public class GetFromNodeLinksRequestHandler : IRequestHandler<GetFromNodeLinksRequest, PaginationResponse<NodeLinkDto>>
{
    private readonly IRepository<NodeLink> _repository;
    private readonly IStringLocalizer<GetFromNodeLinksRequestHandler> _localizer;

    public GetFromNodeLinksRequestHandler(IRepository<NodeLink> repository, IStringLocalizer<GetFromNodeLinksRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<PaginationResponse<NodeLinkDto>> Handle(GetFromNodeLinksRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<NodeLink, PaginationResponse<NodeLinkDto>>)new FromNodeLinksSpec(request.LinkedNodeId, request.Type), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["nodeLink.notfound"], request.LinkedNodeId));
}