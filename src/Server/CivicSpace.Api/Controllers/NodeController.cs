using CivicSpace.Core.Content;
using CivicSpace.Services.Content.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CivicSpace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        private readonly INodeService _nodeService;

        public NodeController(INodeService nodeService)
        {
            _nodeService = nodeService;
        }

        // GET api/<NodeController>/5
        [HttpGet("{id}")]
        public async Task<Node> GetAsync(string id)
        {
            return await _nodeService.GetAsync(id);
        }

        [HttpPost]
        public async Task Post([FromBody] Node node)
        {
            await _nodeService.AddNode(node);
        }

        [HttpPut("{id}")]
        public async void Put(string id, [FromBody] Node node)
        {
            await _nodeService.UpdateNode(node);
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            await _nodeService.DeleteNode(id);
        }
    }
}
