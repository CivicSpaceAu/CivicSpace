using CivicSpace.Core.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CivicSpace.Data
{
    public class AppDbContext : DbContext
    {
        private IConfigurationRoot _configuration;
        private readonly bool _isMigration = false;
        public string _connectionString = String.Empty;

        public AppDbContext(IConfigurationRoot configuration)
        {
            _isMigration = true;
            _configuration = configuration;
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_isMigration)
            {
                string connectionString = _configuration.GetConnectionString("AppDbContext");

                // Override with Azure connection string if exists
                var azureConnectionStringEnvironmentVariable = _configuration["AzureConnectionStringEnvironmentVariable"];
                if (!string.IsNullOrEmpty(azureConnectionStringEnvironmentVariable))
                {
                    connectionString = Environment.GetEnvironmentVariable(azureConnectionStringEnvironmentVariable);
                    //connectionString = AzureMySQL.ToMySQLStandard(connectionString);
                }

                var provider = _configuration["AppDbProvider"];
                if (string.IsNullOrEmpty(provider))
                {
                    provider = "mssql";
                }
                switch(provider.ToLower())
                {
                    case "mssql":
                        optionsBuilder.UseSqlServer(connectionString);
                        break;
                    //case "mysql":
                    //    optionsBuilder.UseMySql(connectionString);
                    //    break;
                    //case "sqlite":
                    //    if (string.IsNullOrEmpty(connectionString))
                    //    {
                    //        var connectionStringBuilder = new Microsoft.Data.Sqlite.SqliteConnectionStringBuilder { DataSource = "banico.db" };
                    //        connectionString = connectionStringBuilder.ToString();
                    //    }
                    //    optionsBuilder.UseSqlite(connectionString);
                    //    break;
                }
            }
        }

        public DbSet<Node> Nodes { get; set; }
        public DbSet<NodeCustomField> NodeCustomFields { get; set; }
        public DbSet<NodeLink> NodeLinks { get; set; }
        public DbSet<NodeReaction> NodeReactions { get; set; }
        public DbSet<NodeTag> NodeTags { get; set; }
        public DbSet<NodeVote> NodeVotes { get; set; }
    }
}
