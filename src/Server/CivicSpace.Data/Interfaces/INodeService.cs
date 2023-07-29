using CivicSpace.Core;

namespace CivicSpace.Data.Interfaces
{
    public interface INodeService
    {
        Task<Node> GetAsync(string id);
        Task<IEnumerable<Node>> GetRootAsync(string tenant, string module, string type);
        Task<IEnumerable<Node>> GetChildrenAsync(string parentNodeId, string type);
        Task<bool> AddAsync(Node node);
        Task<bool> UpdateAsync(Node node);
        Task<bool> DeleteAsync(string id);
    }
}
