using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;
using FSH.WebApi.Application.Common.Exceptions;
using FSH.WebApi.Application.Common.Persistence;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CivicSpace.Application.Content.Nodes;

public class GetNodeRequest : IRequest<NodeDto>
{
    public Guid Id { get; set; }

    public GetNodeRequest(Guid id) => Id = id;
}

public class NodeByIdSpec : Specification<Node, NodeDto>, ISingleResultSpecification
{
    public NodeByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetNodeRequestHandler : IRequestHandler<GetNodeRequest, NodeDto>
{
    private readonly IRepository<Node> _repository;
    private readonly IStringLocalizer<GetNodeRequestHandler> _localizer;

    public GetNodeRequestHandler(IRepository<Node> repository, IStringLocalizer<GetNodeRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<NodeDto> Handle(GetNodeRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Node, NodeDto>)new NodeByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["node.notfound"], request.Id));
}