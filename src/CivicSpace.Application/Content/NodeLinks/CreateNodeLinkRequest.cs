using CivicSpace.Domain.Entities.Content;
using FluentValidation;
using FSH.WebApi.Application.Common.Persistence;
using FSH.WebApi.Application.Common.Validation;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CivicSpace.Application.Content.Nodes;

public class CreateNodeLinkRequest : IRequest<Guid>
{
    public Guid FromNodeId { get; set; } = default!;
    public Guid ToNodeId { get; set; } = default!;
    public string? Type { get; set; }
    public int? Weight { get; set; }
}

public class CreateNodeLinkRequestValidator : CustomValidator<CreateNodeLinkRequest>
{
    public CreateNodeLinkRequestValidator(IReadRepository<NodeLink> repository, IStringLocalizer<CreateNodeLinkRequestValidator> localizer)
    {
        RuleFor(nl => nl.FromNodeId)
            .NotEmpty();
        RuleFor(nl => nl.ToNodeId)
            .NotEmpty();
        RuleFor(nl => nl.Type)
            .MaximumLength(10);
    }
}

public class CreateNodeLinkRequestHandler : IRequestHandler<CreateNodeLinkRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<NodeLink> _repository;

    public CreateNodeLinkRequestHandler(IRepositoryWithEvents<NodeLink> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateNodeLinkRequest request, CancellationToken cancellationToken)
    {
        var nodeLink = new NodeLink(request.FromNodeId, request.ToNodeId, request.Type, request.Weight);

        await _repository.AddAsync(nodeLink, cancellationToken);

        return nodeLink.Id;
    }
}