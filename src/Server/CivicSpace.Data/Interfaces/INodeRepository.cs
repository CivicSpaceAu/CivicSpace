using CivicSpace.Core.Content;
using Microsoft.EntityFrameworkCore;

namespace CivicSpace.Data.Interfaces
{
    public interface INodeRepository
    {
        Task<Node> GetAsync(string id);
        Task<IEnumerable<Node>> GetRootAsync(string tenant, string module, string type);
        Task<IEnumerable<Node>> GetChildrenAsync(string id);
        Task AddNode(Node node);
        Task UpdateNode(Node node);
        Task DeleteNode(string id);
    }
}
