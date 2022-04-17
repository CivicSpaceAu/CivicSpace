using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivicSpace.Domain.Entities.Content
{
    public class NodeMetric
    {
        public Guid Id { get; protected set; } = default!;
        public Guid NodeId { get; set; }
        public Node Node { get; set; }
        public string Key { get; set; }
        public double Value { get; set; }

        public NodeMetric(Guid nodeId, string key, double value)
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
