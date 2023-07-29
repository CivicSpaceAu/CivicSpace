using CivicSpace.Api.Types;
using CivicSpace.Core.Content;
using CivicSpace.Data.Content.Repositories.Interfaces;
using GraphQL;
using GraphQL.Types;

namespace CivicSpace.Api
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation() 
        {
            Field<BooleanGraphType>("createNode")
                .Argument<NonNullGraphType<NodeInputType>>("node")
                .ResolveAsync(async context =>
                {
                    var node = context.GetArgument<Node>("node");
                    var nodeRepository = context.RequestServices.GetRequiredService<INodeRepository>();
                    return await nodeRepository.CreateAsync(node);
                });

            Field<BooleanGraphType>("updateNode")
                .Argument<NonNullGraphType<IdGraphType>>("id")
                .Argument<NonNullGraphType<NodeInputType>>("node")
                .ResolveAsync(async context =>
                {
                    var id = context.GetArgument<string>("id");
                    var node = context.GetArgument<Node>("node");
                    var nodeRepository = context.RequestServices.GetRequiredService<INodeRepository>();
                    return await nodeRepository.UpdateAsync(id, node);
                });

            Field<BooleanGraphType>("deleteNode")
                .Argument<NonNullGraphType<IdGraphType>>("id")
                .ResolveAsync(async context =>
                {
                    var id = context.GetArgument<string>("id");
                    var nodeRepository = context.RequestServices.GetRequiredService<INodeRepository>();
                    return await nodeRepository.DeleteAsync(id);
                });
        }
    }
}
