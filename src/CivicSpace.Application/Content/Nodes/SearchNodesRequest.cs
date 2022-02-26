using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;
using FSH.WebApi.Application.Common.Models;
using FSH.WebApi.Application.Common.Persistence;
using FSH.WebApi.Application.Common.Specification;
using MediatR;

namespace CivicSpace.Application.Content.Nodes;

public class SearchNodesRequest : PaginationFilter, IRequest<PaginationResponse<NodeDto>>
{
}

public class NodesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Node, NodeDto>
{
    public NodesBySearchRequestSpec(SearchNodesRequest request)
        : base(request) =>
        Query.OrderByDescending(c => c.CreatedOn, !request.HasOrderBy());
}

public class SearchNodesRequestHandler : IRequestHandler<SearchNodesRequest, PaginationResponse<NodeDto>>
{
    private readonly IReadRepository<Node> _repository;

    public SearchNodesRequestHandler(IReadRepository<Node> repository) => _repository = repository;

    public async Task<PaginationResponse<NodeDto>> Handle(SearchNodesRequest request, CancellationToken cancellationToken)
    {
        var spec = new NodesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<NodeDto>(list, count, request.PageNumber, request.PageSize);
    }
}
