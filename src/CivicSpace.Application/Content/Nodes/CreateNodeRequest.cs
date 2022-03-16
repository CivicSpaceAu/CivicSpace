using CivicSpace.Domain.Entities.Content;
using FluentValidation;
using FSH.WebApi.Application.Common.Persistence;
using FSH.WebApi.Application.Common.Validation;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CivicSpace.Application.Content.Nodes;

public class CreateNodeRequest : IRequest<Guid>
{
    public string Module { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string Status { get; set; } = default!;
    public string CustomFields { get; set; } = default!;
    public Guid? ParentId { get; set; }
    public string? Path { get; set; }
    public string Tags { get; set; } = default!;
}

public class CreateNodeRequestValidator : CustomValidator<CreateNodeRequest>
{
    public CreateNodeRequestValidator(IReadRepository<Node> repository, IStringLocalizer<CreateNodeRequestValidator> localizer) =>
        RuleFor(p => p.Slug)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (slug, ct) => await repository.GetBySpecAsync(new NodeBySlugSpec(slug), ct) is null)
                .WithMessage((_, slug) => string.Format(localizer["node.alreadyexists"], slug));
}

public class CreateNodeRequestHandler : IRequestHandler<CreateNodeRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Node> _repository;

    public CreateNodeRequestHandler(IRepositoryWithEvents<Node> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateNodeRequest request, CancellationToken cancellationToken)
    {
        var node = new Node(request.Module, request.Type, request.Slug, request.Title, request.Content, request.Status, request.CustomFields, request.ParentId, request.Path, request.Tags);

        await _repository.AddAsync(node, cancellationToken);

        return node.Id;
    }
}