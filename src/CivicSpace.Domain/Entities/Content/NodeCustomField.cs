using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivicSpace.Domain.Entities.Content
{
    public class NodeCustomField
    {
        public Guid Id { get; protected set; } = default!;
        public Guid NodeId { get; set; } = default!;
        public Node Node { get; set; } = default!;
        public string Key { get; set; }
        public string Value { get; set; }

        public NodeCustomField(Guid nodeId, string key, string value)
        {
            NodeId = nodeId;
            Key = key;
            Value = value;
        }

        //public int Weight { get; set; }
        //public int ChildCount { get; set; }
        //public int DescendantCount { get; set; }
        //public int UpVotes { get; set; }
        //public int DownVotes { get; set; }
        //public double Hot { get; set; }

        //public int TotalVotes
        //{
        //    get
        //    {
        //        var votes = UpVotes - DownVotes;
        //        return votes > 0 ? votes : 0;
        //    }
        //}
    }
}
