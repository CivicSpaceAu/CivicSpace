using CivicSpace.Core;
using CivicSpace.Data.Interfaces;

namespace CivicSpace.Data.Services
{
    public class NodeService : INodeService
    {
        private readonly INodeRepository _nodeRepository;

        public NodeService(INodeRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
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

        public async Task<bool> AddAsync(Node node)
        {
            return await _nodeRepository.CreateAsync(node);
        }

        public async Task<bool> UpdateAsync(Node node)
        {
            return await _nodeRepository.UpdateAsync(node.Id, node);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _nodeRepository.DeleteAsync(id);
        }
    }
}
