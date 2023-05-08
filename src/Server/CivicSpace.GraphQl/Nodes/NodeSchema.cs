using GraphQL.Types;

namespace CivicSpace.GraphQl.Nodes
{
    public class NodeSchema : Schema
    {
        public NodeSchema(IServiceProvider services) : base(services)
        {
            Query = new NodeQuery();
            Mutation = new NodeMutation();
        }
    }
}
