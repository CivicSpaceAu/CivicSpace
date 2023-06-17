using CivicSpace.Core.Content;
using CivicSpace.Data.Content.Repositories.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Linq.Expressions;

namespace CivicSpace.Data.Content.Repositories
{
    public class NodeRepository : INodeRepository
    {
        public readonly Container _container;

        private int _maxPageSize = 40;

        public NodeRepository(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task<IEnumerable<Node>> GetByAsync(Expression<Func<Node, bool>> predicate)
        {
            var queryable = _container.GetItemLinqQueryable<Node>().Where(predicate);
            var iterator = queryable.ToFeedIterator();
            var results = new List<Node>();

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                results.AddRange(response);
            }

            return results;
        }

        public async Task<Node> GetByIdAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Node>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
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
                var response = await _container.CreateItemAsync(node);
                return response.StatusCode == System.Net.HttpStatusCode.Created;
            }
            catch (CosmosException ex)
            {
                return false;
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
                var response = await _container.ReplaceItemAsync(node, id, new PartitionKey(id));
                return response.StatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (CosmosException ex)
            {
                return false;
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
                var response = await _container.DeleteItemAsync<Node>(id, new PartitionKey(id));
                return response.StatusCode == System.Net.HttpStatusCode.NoContent;
            }
            catch (CosmosException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}