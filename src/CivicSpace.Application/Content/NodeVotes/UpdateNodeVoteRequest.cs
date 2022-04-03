using Ardalis.Specification;
using CivicSpace.Domain.Entities.Content;
using FluentValidation;
using FSH.WebApi.Application.Common.Exceptions;
using FSH.WebApi.Application.Common.Persistence;
using FSH.WebApi.Application.Common.Validation;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CivicSpace.Application.Content.Nodes;

public class UpdateNodeVoteRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public Guid NodeId { get; set; }
    public Guid CreatedBy { get; set; }
    public short Score { get; set; }
}

public class UpdateNodeVoteRequestValidator : CustomValidator<UpdateNodeVoteRequest>
{
    public UpdateNodeVoteRequestValidator(IRepository<NodeVote> repository, IStringLocalizer<UpdateNodeVoteRequestValidator> localizer)
    {
        RuleFor(p => p.NodeId)
            .NotEmpty();
        RuleFor(p => p.CreatedBy)
            .NotEmpty();
        RuleFor(p => p.Score)
            .NotEmpty();
    }
}

public class UpdateNodeVoteRequestHandler : IRequestHandler<UpdateNodeVoteRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<NodeVote> _repository;
    private readonly IStringLocalizer<UpdateNodeRequestHandler> _localizer;

    public UpdateNodeVoteRequestHandler(IRepositoryWithEvents<NodeVote> repository, IStringLocalizer<UpdateNodeRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(UpdateNodeVoteRequest request, CancellationToken cancellationToken)
    {
        var nodeVote = await _repository.GetBySpecAsync(new NodeVoteSpec(request.NodeId, request.CreatedBy));
        _ = nodeVote ?? throw new NotFoundException(_localizer["nodeVote.notfound"]);
        nodeVote.Update(request.Score);
        await _repository.UpdateAsync(nodeVote, cancellationToken);
        return request.Id;
    }
}
