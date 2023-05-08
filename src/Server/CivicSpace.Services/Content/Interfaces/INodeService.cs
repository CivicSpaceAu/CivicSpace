using CivicSpace.Core.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivicSpace.Services.Content.Interfaces
{
    public interface INodeService
    {
        Task<Node> GetAsync(string id);
        Task<IEnumerable<Node>> GetRootAsync(string tenant, string module, string type);
        Task<IEnumerable<Node>> GetChildrenAsync(string parentNodeId, string type);
        Task<Node> AddAsync(Node node);
        Task<Node> UpdateAsync(Node node);
        Task DeleteAsync(string id);
    }
}
