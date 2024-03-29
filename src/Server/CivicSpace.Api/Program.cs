using CivicSpace.Data;
using GraphQL;
using GraphQL.MicrosoftDI;

namespace CivicSpace.Api
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            var configuration = configurationBuilder.Build();
            builder.Services.AddSingleton<IConfigurationRoot>(configuration);
            builder.Services.ConfigureDataServices(configuration);

            builder.Services.AddGraphQL(b => b
                //.AddHttpMiddleware<ISchema>()
                //.AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User })
                .AddSystemTextJson()
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
                .AddSchema<AppSchema>(services => new AppSchema(new SelfActivatingServiceProvider(services)))
                .AddGraphTypes(typeof(AppSchema).Assembly));
            builder.Services.AddControllers();

            var app = builder.Build();
            //app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseGraphQL("/graphql");
            app.UseGraphQLGraphiQL();
            app.Run();
        }
    }
}
