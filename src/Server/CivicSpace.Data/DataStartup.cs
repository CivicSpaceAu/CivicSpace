using CivicSpace.Data.Repositories;
using CivicSpace.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CivicSpace.Data
{
    public static class DataStartup
    {
        public static void AddData(this IServiceCollection services, IConfiguration configuration)
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
        }
    }
}