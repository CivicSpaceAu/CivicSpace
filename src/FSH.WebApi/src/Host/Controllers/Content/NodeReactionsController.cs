using CivicSpace.Application.Content.Nodes;
using FSH.WebApi.Host.Controllers;

namespace CivicSpace.Web.Backend.Controllers;

public class NodeReactionsController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.NodeVotes)]
    [OpenApiOperation("Search nodes using available filters.", "")]
    public Task<PaginationResponse<NodeDto>> SearchAsync(SearchNodesRequest request)
    {
        return Mediator.Send(request);
    }

    //[HttpGet("{id:guid}")]
    //[MustHavePermission(FSHAction.View, FSHResource.NodeVotes)]
    //[OpenApiOperation("Get node details.", "")]
    //public Task<NodeVoteDto> GetAsync(Guid id)
    //{
    //    return Mediator.Send(new GetNodeReactionsRequest(id));
    //}

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.NodeVotes)]
    [OpenApiOperation("Create a new node vote.", "")]
    public Task<Guid> CreateAsync(CreateNodeVoteRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Nodes)]
    [OpenApiOperation("Update a node vote.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateNodeVoteRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Nodes)]
    [OpenApiOperation("Delete a node vote.", "")]
    public Task<Guid> DeleteAsync(Guid id, Guid createdBy)
    {
        return Mediator.Send(new DeleteNodeVoteRequest(id, createdBy));
    }
}
