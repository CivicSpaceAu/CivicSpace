using CivicSpace.Core;
using Microsoft.EntityFrameworkCore;

namespace CivicSpace.Data.Interfaces
{
    public interface INodeRepository
    {
        Task<Node> GetByIdAsync(string id);
        Task<IEnumerable<Node>> GetRootAsync(string tenant, string module, string type);
        Task<IEnumerable<Node>> GetChildrenAsync(string id, string type);
        Task<bool> CreateAsync(Node node);
        Task<bool> UpdateAsync(string id, Node node);
        Task<bool> DeleteAsync(string id);
    }
}
