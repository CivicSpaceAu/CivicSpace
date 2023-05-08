using CivicSpace.Data.Repositories;
using CivicSpace.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CivicSpace.Data
{
    public class DataStartup
  {
    public void ConfigureServices(IConfiguration configuration, IServiceCollection services)
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

    //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    //{
    //  using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
    //  {
    //    var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
    //    context.Database.Migrate();
    //  }
    //}
  }
}