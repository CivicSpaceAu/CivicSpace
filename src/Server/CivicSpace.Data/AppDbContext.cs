using CivicSpace.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CivicSpace.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfigurationRoot _configuration;

        public AppDbContext(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Node> Nodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>().ToContainer("Nodes");
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
