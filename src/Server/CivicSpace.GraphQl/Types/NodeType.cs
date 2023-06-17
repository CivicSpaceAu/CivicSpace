using CivicSpace.Core.Content;
using GraphQL.Types;

namespace CivicSpace.GraphQl.Types
{
    public class NodeType : ObjectGraphType<Node>
    {
        public NodeType()
        {
            Field(n => n.Id, type: typeof(IdGraphType), nullable: true)
                .Description("Id property of node object.");
            Field(n => n.Tenant, nullable: true);
            Field(n => n.Module, nullable: true);
            Field(n => n.Type, nullable: true);
            Field(n => n.Title, nullable: true);
            Field(n => n.Content, nullable: true);
            Field(n => n.Status, nullable: true);
            Field(n => n.Slug, nullable: true);
            Field(n => n.ParentNodeId, nullable: true);
            Field(n => n.Path, nullable: true);
        }
    }
}
