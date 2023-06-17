using CivicSpace.Data.Content.Repositories.Interfaces;
using CivicSpace.GraphQl.Types;
using GraphQL;
using GraphQL.Types;

namespace CivicSpace.GraphQl
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(INodeRepository nodeRepository)
        {
            Name = nameof(AppQuery);

            Field<ListGraphType<NodeType>>("node")
                .Argument<StringGraphType>("id", "node id")
                .ResolveAsync(async context =>
                    await nodeRepository.GetByIdAsync(context.GetArgument<string>("id")));
        }
    }
}
