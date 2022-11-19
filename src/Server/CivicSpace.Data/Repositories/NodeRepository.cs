using CivicSpace.Core.Content;
using CivicSpace.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CivicSpace.Data.Repositories
{
    public class NodeRepository : INodeRepository
    {
        public readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;

        private int _maxPageSize = 40;

        public NodeRepository(
            AppDbContext dbContext,
            IConfiguration configuration
        )
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<Node> GetNodeAsync(string id)
        {
            return await _dbContext.Nodes.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<IEnumerable<Node>> GetNodesByParentIdAsync(string parentNodeId)
        {
            return await _dbContext.Nodes.Where(n => n.ParentNodeId == parentNodeId).ToListAsync();
        }

        public async Task AddNode(Node node)
        {
            _dbContext.Nodes.Add(node);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateNode(Node node)
        {
            _dbContext.Nodes.Update(node);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteNode(string id)
        {
            var itemToRemove = _dbContext.Nodes.SingleOrDefault(x => x.Id == id);

            if (itemToRemove != null)
            {
                _dbContext.Nodes.Remove(itemToRemove);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}