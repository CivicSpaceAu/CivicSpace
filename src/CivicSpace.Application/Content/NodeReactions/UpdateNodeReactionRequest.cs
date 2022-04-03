using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;
using FluentValidation;
using FSH.WebApi.Application.Common.Exceptions;
using FSH.WebApi.Application.Common.Persistence;
using FSH.WebApi.Application.Common.Validation;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CivicSpace.Application.Content.Nodes;

public class UpdateNodeReactionRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public Guid NodeId { get; set; } = default!;
    public Guid CreatedBy { get; set; } = default!;
    public string Type { get; set; } = default!;
}

public class UpdateNodeReactionRequestValidator : CustomValidator<UpdateNodeReactionRequest>
{
    public UpdateNodeReactionRequestValidator(IRepository<NodeReaction> repository, IStringLocalizer<UpdateNodeReactionRequestValidator> localizer)
    {
        RuleFor(nr => nr.NodeId)
            .NotEmpty();
        RuleFor(nr => nr.CreatedBy)
            .NotEmpty();
        RuleFor(nr => nr.Type)
            .NotEmpty()
            .MaximumLength(10);
    }
}

public class UpdateNodeReactionRequestHandler : IRequestHandler<UpdateNodeReactionRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<NodeReaction> _repository;
    private readonly IStringLocalizer<UpdateNodeReactionRequestHandler> _localizer;

    public UpdateNodeReactionRequestHandler(IRepositoryWithEvents<NodeReaction> repository, IStringLocalizer<UpdateNodeReactionRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(UpdateNodeReactionRequest request, CancellationToken cancellationToken)
    {
        var nodeReaction = await _repository.GetBySpecAsync(new NodeReactionSpec(request.NodeId, request.CreatedBy));

        _ = nodeReaction ?? throw new NotFoundException(_localizer["nodeReaction.notfound"]);

        nodeReaction.Update(request.Type);

        await _repository.UpdateAsync(nodeReaction, cancellationToken);

        return request.Id;
    }
}
