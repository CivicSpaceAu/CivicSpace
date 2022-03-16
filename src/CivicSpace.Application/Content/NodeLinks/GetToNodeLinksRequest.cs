using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;
using FSH.WebApi.Application.Common.Exceptions;
using FSH.WebApi.Application.Common.Persistence;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CivicSpace.Application.Content.Nodes;

public class GetToNodeLinksRequest : IRequest<IEnumerable<NodeLinkDto>>
{
    public Guid FromNodeId { get; set; }
    public string Type { get; set; }

    public GetToNodeLinksRequest(Guid fromNodeId, string type)
    {
        FromNodeId = fromNodeId;
        Type = type;
    }
}

public class ToNodeLinksSpec : Specification<NodeLink, IEnumerable<NodeLinkDto>>, ISingleResultSpecification
{
    public ToNodeLinksSpec(Guid fromNodeId, string type) =>
        Query.Where(nl => nl.FromNodeId == fromNodeId && (string.IsNullOrEmpty(type) || nl.Type == type));
}

public class GetToNodeLinksRequestHandler : IRequestHandler<GetToNodeLinksRequest, IEnumerable<NodeLinkDto>>
{
    private readonly IRepository<NodeLink> _repository;
    private readonly IStringLocalizer<GetFromNodeLinksRequestHandler> _localizer;

    public GetToNodeLinksRequestHandler(IRepository<NodeLink> repository, IStringLocalizer<GetFromNodeLinksRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<IEnumerable<NodeLinkDto>> Handle(GetToNodeLinksRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<NodeLink, IEnumerable<NodeLinkDto>>)new ToNodeLinksSpec(request.FromNodeId, request.Type), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["nodeLink.notfound"], request.FromNodeId));
}