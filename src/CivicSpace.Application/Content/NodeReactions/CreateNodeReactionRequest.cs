using CivicSpace.Domain.Entities.Content;
using FluentValidation;
using FSH.WebApi.Application.Common.Persistence;
using FSH.WebApi.Application.Common.Validation;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CivicSpace.Application.Content.Nodes;

public class CreateNodeReactionRequest : IRequest<Guid>
{
    public Guid NodeId { get; set; } = default!;
    public string ReactionType { get; set; } = default!;
}

public class CreateNodeReactionRequestValidator : CustomValidator<CreateNodeReactionRequest>
{
    public CreateNodeReactionRequestValidator(IReadRepository<NodeReaction> repository, IStringLocalizer<CreateNodeReactionRequestValidator> localizer)
    {
        RuleFor(n => n.NodeId)
            .NotEmpty();
        RuleFor(n => n.ReactionType)
            .NotEmpty()
            .MaximumLength(10);
    }
}

public class CreateNodeReactionRequestHandler : IRequestHandler<CreateNodeReactionRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<NodeReaction> _repository;

    public CreateNodeReactionRequestHandler(IRepositoryWithEvents<NodeReaction> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateNodeReactionRequest request, CancellationToken cancellationToken)
    {
        var nodeReaction = new NodeReaction(request.NodeId, request.ReactionType);

        await _repository.AddAsync(nodeReaction, cancellationToken);

        return nodeReaction.Id;
    }
}