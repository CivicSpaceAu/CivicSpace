using CivicSpace.Core.Content;
using CivicSpace.Data.Repositories.Interfaces;
using CivicSpace.Services.Content.Interfaces;

namespace CivicSpace.Services.Content
{
    public class NodeService : INodeService
    {
        private readonly INodeRepository _nodeRepository;

        public NodeService(INodeRepository nodeRepository)
        {
            _nodeRepository= nodeRepository;
        }

        public async Task<Node> GetAsync(string id)
        {
            return await _nodeRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Node>> GetRootAsync(string tenant, string module, string type)
        {
            return await _nodeRepository.GetRootAsync(tenant, module, type);
        }

        public async Task<IEnumerable<Node>> GetChildrenAsync(string id, string type)
        {
            return await _nodeRepository.GetChildrenAsync(id, type);
        }

        public async Task<Node> AddAsync(Node node)
        {
            return await _nodeRepository.CreateAsync(node);
        }

        public async Task<Node> UpdateAsync(Node node)
        {
            return await _nodeRepository.UpdateAsync(node.Id, node);
        }

        public async Task DeleteAsync(string id)
        {
            await _nodeRepository.DeleteAsync(id);
        }
    }
}
