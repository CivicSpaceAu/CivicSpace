using CivicSpace.Core.Content;
using Microsoft.EntityFrameworkCore;

namespace CivicSpace.Data.Repositories.Interfaces
{
    public interface INodeRepository
    {
        Task<Node> GetByIdAsync(string id);
        Task<IEnumerable<Node>> GetRootAsync(string tenant, string module, string type);
        Task<IEnumerable<Node>> GetChildrenAsync(string id, string type);
        Task<Node> CreateAsync(Node node);
        Task<Node> UpdateAsync(string id, Node node);
        Task DeleteAsync(string id);
    }
}
