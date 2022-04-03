using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;
using FluentValidation;
using FSH.WebApi.Application.Common.Exceptions;
using FSH.WebApi.Application.Common.Persistence;
using FSH.WebApi.Application.Common.Validation;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CivicSpace.Application.Content.Nodes;

public class UpdateNodeLinkRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public Guid FromNodeId { get; set; } = Guid.Empty;
    public Guid ToNodeId { get; set; } = Guid.Empty;
    public string? Type { get; set; }
    public int? Weight { get; set; }
}

public class UpdateNodeLinkRequestValidator : CustomValidator<UpdateNodeLinkRequest>
{
    public UpdateNodeLinkRequestValidator(IRepository<Node> repository, IStringLocalizer<UpdateNodeRequestValidator> localizer)
    {
        RuleFor(p => p.FromNodeId)
            .NotEmpty();
        RuleFor(p => p.ToNodeId)
            .NotEmpty();
        RuleFor(p => p.Type)
            .MaximumLength(10);
    }
}

public class UpdateNodeLinkRequestHandler : IRequestHandler<UpdateNodeLinkRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<NodeLink> _repository;
    private readonly IStringLocalizer<UpdateNodeLinkRequestHandler> _localizer;

    public UpdateNodeLinkRequestHandler(IRepositoryWithEvents<NodeLink> repository, IStringLocalizer<UpdateNodeLinkRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(UpdateNodeLinkRequest request, CancellationToken cancellationToken)
    {
        var nodeLink = await _repository.GetBySpecAsync(new NodeLinkSpec(request.FromNodeId, request.ToNodeId));
        _ = nodeLink ?? throw new NotFoundException(string.Format(_localizer["node.notfound"], request.Id));
        nodeLink.Update(request.Type, request.Weight);
        await _repository.UpdateAsync(nodeLink, cancellationToken);
        return request.Id;
    }
}
