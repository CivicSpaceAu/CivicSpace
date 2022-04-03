using CivicSpace.Application.Content.Nodes;
using FSH.WebApi.Host.Controllers;

namespace CivicSpace.Web.Backend.Controllers;

public class NodeLinksController : VersionedApiController
{
    [HttpPost("getFrom")]
    [MustHavePermission(FSHAction.Search, FSHResource.NodeLinks)]
    [OpenApiOperation("Get Fro.", "")]
    public Task<PaginationResponse<NodeLinkDto>> SearchAsync(GetFromNodeLinksRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPost("getTo")]
    [MustHavePermission(FSHAction.Search, FSHResource.NodeLinks)]
    [OpenApiOperation("Search nodes using available filters.", "")]
    public Task<PaginationResponse<NodeLinkDto>> SearchAsync(GetToNodeLinksRequest request)
    {
        return Mediator.Send(request);
    }

    //[HttpGet("{id:guid}")]
    //[MustHavePermission(FSHAction.View, FSHResource.NodeLinks)]
    //[OpenApiOperation("Get node details.", "")]
    //public Task<PaginationResponse<NodeLinkDto>> GetAsync(Guid id)
    //{
    //    return Mediator.Send(new GetNodeLinksRequest(id));
    //}

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.NodeLinks)]
    [OpenApiOperation("Create a new node link.", "")]
    public Task<Guid> CreateAsync(CreateNodeLinkRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.NodeLinks)]
    [OpenApiOperation("Update a node link.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateNodeLinkRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.NodeLinks)]
    [OpenApiOperation("Delete a node link.", "")]
    public Task<Guid> DeleteAsync(Guid fromNodeId, Guid toNodeId)
    {
        return Mediator.Send(new DeleteNodeLinkRequest(fromNodeId, toNodeId));
    }
}
