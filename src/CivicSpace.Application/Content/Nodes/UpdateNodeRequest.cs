using CivicSpace.Domain.Entities.Content;
using FluentValidation;
using FSH.WebApi.Application.Common.Exceptions;
using FSH.WebApi.Application.Common.Persistence;
using FSH.WebApi.Application.Common.Validation;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CivicSpace.Application.Content.Nodes;

public class UpdateNodeRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Slug { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string? Content { get; set; }
    public string Status { get; set; } = default!;
    public string? CustomFields { get; set; }
    public string? Tags { get; set; }
}

public class UpdateNodeRequestValidator : CustomValidator<UpdateNodeRequest>
{
    public UpdateNodeRequestValidator(IRepository<Node> repository, IStringLocalizer<UpdateNodeRequestValidator> localizer) =>
        RuleFor(p => p.Slug)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (node, slug, ct) =>
                    await repository.GetBySpecAsync(new NodeBySlugSpec(slug), ct)
                        is not Node existingNode || existingNode.Id == node.Id)
                .WithMessage((_, slug) => string.Format(localizer["node.alreadyexists"], slug));
}

public class UpdateNodeRequestHandler : IRequestHandler<UpdateNodeRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Node> _repository;
    private readonly IStringLocalizer<UpdateNodeRequestHandler> _localizer;

    public UpdateNodeRequestHandler(IRepositoryWithEvents<Node> repository, IStringLocalizer<UpdateNodeRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(UpdateNodeRequest request, CancellationToken cancellationToken)
    {
        var node = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = node ?? throw new NotFoundException(string.Format(_localizer["node.notfound"], request.Id));

        node.Update(request.Slug, request.Title, request.Content, request.Status, request.CustomFields, request.Tags);

        await _repository.UpdateAsync(node, cancellationToken);

        return request.Id;
    }
}
