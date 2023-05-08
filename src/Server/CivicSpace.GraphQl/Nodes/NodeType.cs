using CivicSpace.Core.Content;
using GraphQL.Types;

namespace CivicSpace.GraphQl.Nodes
{
    public class NodeType : ObjectGraphType<Node>
    {
        public NodeType()
        {
            Field(n => n.Id);
            Field(n => n.Tenant);
            Field(n => n.Module);
            Field(n => n.Type);
            Field(n => n.Title);
            Field(n => n.Content);
            Field(n => n.Status);
            Field(n => n.Slug);
            Field(n => n.ParentNodeId);
            Field(n => n.Path);
        }
    }
}
