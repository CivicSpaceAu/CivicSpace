using CivicSpace.Core.Content;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CivicSpace.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfigurationRoot _configuration;
        private readonly CosmosClient _cosmosClient;

        public AppDbContext(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Node> Nodes { get; set; }
        public DbSet<NodeCustomField> NodeCustomFields { get; set; }
        public DbSet<NodeLink> NodeLinks { get; set; }
        public DbSet<NodeReaction> NodeReactions { get; set; }
        public DbSet<NodeTag> NodeTags { get; set; }
        public DbSet<NodeVote> NodeVotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>().ToContainer("Nodes");
            modelBuilder.Entity<NodeCustomField>().ToContainer("NodeCustomFields");
            modelBuilder.Entity<NodeLink>().ToContainer("NodeLinks");
            modelBuilder.Entity<NodeReaction>().ToContainer("NodeReactions");
            modelBuilder.Entity<NodeTag>().ToContainer("NodeTags");
            modelBuilder.Entity<NodeVote>().ToContainer("NodeVotes");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cosmosDbConnectionString = _configuration.GetConnectionString("CosmosDbConnection");
            var cosmosDbName = _configuration["CosmosDbDatabaseName"];
            if (!string.IsNullOrWhiteSpace(cosmosDbConnectionString))
            {
                optionsBuilder.UseCosmos(cosmosDbConnectionString, cosmosDbName);
            }
            else
            {
                var cosmosDbEndpoint = _configuration["CosmosDbEndpoint"] ?? throw new ArgumentNullException("Configuration:CosmosDbEndpoint");
                var cosmosDbKey = _configuration["CosmosDbKey"] ?? throw new ArgumentNullException("Configuration:CosmosDbKey");
                optionsBuilder.UseCosmos(cosmosDbEndpoint, cosmosDbKey, cosmosDbName);
            }
        }
    }
}
