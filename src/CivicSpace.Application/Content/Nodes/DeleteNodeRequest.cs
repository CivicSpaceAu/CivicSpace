using CivicSpace.Domain.Entities.Content;
using FSH.WebApi.Application.Common.Exceptions;
using FSH.WebApi.Application.Common.Persistence;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CivicSpace.Application.Content.Nodes;

public class DeleteNodeRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteNodeRequest(Guid id) => Id = id;
}

public class DeleteNodeRequestHandler : IRequestHandler<DeleteNodeRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Node> _nodeRepo;
    private readonly IStringLocalizer<DeleteNodeRequestHandler> _localizer;

    public DeleteNodeRequestHandler(IRepositoryWithEvents<Node> nodeRepo, IStringLocalizer<DeleteNodeRequestHandler> localizer) =>
        (_nodeRepo, _localizer) = (nodeRepo, localizer);

    public async Task<Guid> Handle(DeleteNodeRequest request, CancellationToken cancellationToken)
    {
        var node = await _nodeRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = node ?? throw new NotFoundException(_localizer["node.notfound"]);

        await _nodeRepo.DeleteAsync(node, cancellationToken);

        return request.Id;
    }
}
