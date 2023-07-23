using CivicSpace.Data.Content.Repositories.Interfaces;
using CivicSpace.Api.Types;
using GraphQL;
using GraphQL.Types;

namespace CivicSpace.Api
{
    public class AppQuery : ObjectGraphType
    {
        private readonly INodeRepository _nodeRepository;

        public AppQuery(INodeRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;

            Name = nameof(AppQuery);

            Field<ListGraphType<NodeType>>("node")
                .Argument<StringGraphType>("id", "node id")
                .ResolveAsync(async context =>
                    await _nodeRepository.GetByIdAsync(context.GetArgument<string>("id")));
        }
    }
}
