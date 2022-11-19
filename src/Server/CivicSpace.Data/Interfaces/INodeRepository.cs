using CivicSpace.Core.Content;

namespace CivicSpace.Data.Interfaces
{
    public interface INodeRepository
    {
        Task<Node> GetNodeAsync(string id);
        Task<IEnumerable<Node>> GetNodesByParentIdAsync(string parentNodeId);
    }
}
