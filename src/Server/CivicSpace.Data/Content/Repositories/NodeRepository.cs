using CivicSpace.Core.Content;
using CivicSpace.Data.Content.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CivicSpace.Data.Content.Repositories
{
    public class NodeRepository : INodeRepository
    {
        private readonly AppDbContext _dbContext;

        private int _maxPageSize = 40;

        public NodeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Node>> GetByAsync(Expression<Func<Node, bool>> predicate)
        {
            return await _dbContext.Nodes.Where(predicate).ToListAsync();
        }

        public async Task<Node> GetByIdAsync(string id)
        {
            return await _dbContext.Nodes.FindAsync(id);
        }

        public async Task<IEnumerable<Node>> GetRootAsync(string tenant, string module, string type)
        {
            return await GetByAsync(n =>
                n.Tenant == tenant &&
                n.Module == module &&
                n.Type == type &&
                n.ParentNodeId == "");
        }

        public async Task<IEnumerable<Node>> GetChildrenAsync(string id, string type)
        {
            return await GetByAsync(n =>
                n.ParentNodeId == id &&
                n.Type == type);
        }

        public async Task<bool> CreateAsync(Node node)
        {
            try
            {
                _dbContext.Nodes.Add(node);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(string id, Node node)
        {
            try
            {
                var originalNode = await _dbContext.Nodes.FindAsync(id);
                originalNode.Copy(node);
                _dbContext.Nodes.Update(originalNode);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var node = await _dbContext.Nodes.FindAsync(id);
                _dbContext.Nodes.Remove(node);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}