using CivicSpace.Data;
using GraphQL;

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
            builder.Services.AddGraphQL(b => b
                //.AddHttpMiddleware<ISchema>()
                //.AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User })
                .AddSystemTextJson()
                .AddSchema<AppSchema>()
                .AddGraphTypes(typeof(AppSchema).Assembly));
            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
