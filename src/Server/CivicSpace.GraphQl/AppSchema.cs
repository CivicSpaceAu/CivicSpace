using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace CivicSpace.GraphQl
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();
            Mutation = provider.GetRequiredService<AppMutation>();
        }
    }
}
