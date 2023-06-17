using CivicSpace.Data.Content.Repositories;
using CivicSpace.Data.Content.Repositories.Interfaces;
using CivicSpace.Data.Content.Services.Interfaces;
using CivicSpace.Data.Content.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CivicSpace.Data
{
    public static class DataStartup
    {
        public static void ConfigureDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseCosmos(
                    configuration.GetConnectionString("CosmosDbConnection") ?? configuration["CosmosDbEndpoint"],
                    configuration["CosmosDbKey"],
                    configuration["CosmosDbDatabaseName"]
                );
            });
            services.AddOptions();
            services.AddScoped<INodeRepository, NodeRepository>();
            services.AddScoped<INodeService, NodeService>();
        }
    }
}