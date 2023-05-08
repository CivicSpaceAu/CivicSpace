using CivicSpace.Core.Content;
using CivicSpace.Data.Repositories.Interfaces;

namespace CivicSpace.Services.Content
{
    public class NodeService
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

        public async Task<IEnumerable<Node>> GetChildrenAsync(string parentNodeId, string type)
        {
            return await _nodeRepository.GetChildrenAsync(parentNodeId, type);
        }

        public async Task AddAsync(Node node)
        {
            await _nodeRepository.CreateAsync(node);
        }

        public async Task UpdateAsync(Node node)
        {
            await _nodeRepository.UpdateAsync(node.Id, node);
        }

        public async Task DeleteAsync(string id)
        {
            await _nodeRepository.DeleteAsync(id);
        }
    }
}
