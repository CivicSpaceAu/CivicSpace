using CivicSpace.Data.Interfaces;
using CivicSpace.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CivicSpace.Data
{
    public class DataStartup
  {
    public void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
      string appDbContextConnectionString = configuration.GetConnectionString("AppDbContext");

      // Override with Azure connection string if exists
      var azureConnectionStringEnvironmentVariable = configuration["AzureConnectionStringEnvironmentVariable"];
      if (!string.IsNullOrEmpty(azureConnectionStringEnvironmentVariable))
      {
          appDbContextConnectionString = Environment.GetEnvironmentVariable(azureConnectionStringEnvironmentVariable);
      }

      var provider = configuration["AppDbProvider"];
      if (string.IsNullOrEmpty(provider))
      {
          provider = "mssql";
      }
      switch(provider.ToLower())
      {
          case "mssql":
              services.AddDbContext<AppDbContext>(options =>
                  options.UseSqlServer(appDbContextConnectionString,
                  optionsBuilder => optionsBuilder.MigrationsAssembly("CivicSpace.Data")),
                  ServiceLifetime.Scoped);
              break;
          //case "mysql":
          //    services.AddDbContext<AppDbContext>(options =>
          //        options.UseMySql(appDbContextConnectionString,
          //        optionsBuilder => optionsBuilder.MigrationsAssembly("Banico.EntityFrameworkCore")),
          //        ServiceLifetime.Scoped);
          //    break;
          //case "sqlite":
          //    if (string.IsNullOrEmpty(appDbContextConnectionString))
          //    {
          //        var connectionStringBuilder = new Microsoft.Data.Sqlite.SqliteConnectionStringBuilder { DataSource = "banico.db" };
          //        appDbContextConnectionString = connectionStringBuilder.ToString();
          //    }
          //    services.AddDbContext<AppDbContext>(options =>
          //        options.UseSqlite(appDbContextConnectionString,
          //        optionsBuilder => optionsBuilder.MigrationsAssembly("Banico.EntityFrameworkCore")),
          //        ServiceLifetime.Scoped);
          //    break;
      }

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