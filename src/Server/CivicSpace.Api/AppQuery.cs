using CivicSpace.Data.Content.Repositories.Interfaces;
using CivicSpace.Api.Types;
using GraphQL;
using GraphQL.Types;

namespace CivicSpace.Api
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery()
        {
            Name = nameof(AppQuery);

            Field<ListGraphType<NodeType>>("node")
                .Argument<StringGraphType>("id", "node id")
                .ResolveAsync(async context =>
                {
                    var nodeRepository = context.RequestServices.GetRequiredService<INodeRepository>();
                    return await nodeRepository.GetByIdAsync(context.GetArgument<string>("id"));
                });
        }
    }
}
