using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivicSpace.GraphQl.Types
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
