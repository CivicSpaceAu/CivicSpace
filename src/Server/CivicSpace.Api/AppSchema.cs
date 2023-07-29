using GraphQL.Types;

namespace CivicSpace.Api
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<AppQuery>();
            Mutation = serviceProvider.GetRequiredService<AppMutation>();
        }
    }
}
