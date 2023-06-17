using CivicSpace.Data;
using CivicSpace.GraphQl;

namespace CivicSpace.Api
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            var configuration = configurationBuilder.Build();
            builder.Services.AddSingleton<IConfigurationRoot>(configuration);
            builder.Services.ConfigureDataServices(configuration);
            builder.Services.ConfigureGraphQlServices(configuration);
            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
