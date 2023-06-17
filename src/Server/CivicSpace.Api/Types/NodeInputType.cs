using GraphQL.Types;

namespace CivicSpace.Api.Types
{
    public class NodeInputType : InputObjectGraphType
    {
        public NodeInputType() 
        {
            Name = "NodeInput";
            Field<StringGraphType>("Tenant");
            Field<StringGraphType>("Module");
            Field<StringGraphType>("Type");
            Field<StringGraphType>("Title");
            Field<StringGraphType>("Content");
            Field<StringGraphType>("Status");
            Field<StringGraphType>("Slug");
            Field<StringGraphType>("ParentNodeId");
            Field<StringGraphType>("Path");
        }
    }
}
