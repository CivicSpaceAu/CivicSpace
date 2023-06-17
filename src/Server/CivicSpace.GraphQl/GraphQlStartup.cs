using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CivicSpace.GraphQl
{
    public static class GraphQlStartup
    {
        public static void ConfigureGraphQlServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGraphQL(b => b
                //.AddHttpMiddleware<ISchema>()
                //.AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User })
                .AddSystemTextJson()
                .AddSchema<AppSchema>()
                .AddGraphTypes(typeof(AppSchema).Assembly));
        }
    }
}
