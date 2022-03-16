using CivicSpace.Domain.Entities.Content;
using FluentValidation;
using FSH.WebApi.Application.Common.Persistence;
using FSH.WebApi.Application.Common.Validation;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CivicSpace.Application.Content.Nodes;

public class CreateNodeVoteRequest : IRequest<Guid>
{
    public Guid NodeId { get; set; } = default!;
    public short Score { get; set; } = default!;
}

public class CreateNodeVoteRequestValidator : CustomValidator<CreateNodeVoteRequest>
{
    public CreateNodeVoteRequestValidator(IReadRepository<NodeVote> repository, IStringLocalizer<CreateNodeVoteRequestValidator> localizer) =>
        RuleFor(p => p.NodeId)
            .NotEmpty();
}

public class CreateNodeVoteRequestHandler : IRequestHandler<CreateNodeVoteRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<NodeVote> _repository;

    public CreateNodeVoteRequestHandler(IRepositoryWithEvents<NodeVote> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateNodeVoteRequest request, CancellationToken cancellationToken)
    {
        var node = new NodeVote(request.NodeId, request.Score);

        await _repository.AddAsync(node, cancellationToken);

        return node.Id;
    }
}