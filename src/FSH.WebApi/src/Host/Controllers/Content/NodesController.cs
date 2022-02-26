using CivicSpace.Application.Content.Nodes;
using FSH.WebApi.Host.Controllers;

namespace CivicSpace.Web.Backend.Controllers;

public class NodesController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Nodes)]
    [OpenApiOperation("Search nodes using available filters.", "")]
    public Task<PaginationResponse<NodeDto>> SearchAsync(SearchNodesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Nodes)]
    [OpenApiOperation("Get node details.", "")]
    public Task<NodeDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetNodeRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Nodes)]
    [OpenApiOperation("Create a new node.", "")]
    public Task<Guid> CreateAsync(CreateNodeRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Nodes)]
    [OpenApiOperation("Update a node.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateNodeRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Nodes)]
    [OpenApiOperation("Delete a node.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteNodeRequest(id));
    }
}
