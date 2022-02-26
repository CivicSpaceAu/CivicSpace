using FSH.WebApi.Domain.Common.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Domain.Entities.Content
{
    public class NodeLink : AuditableEntity
    {
        [ForeignKey("FromNode")]
        public string FromNodeId { get; set; }
        [ForeignKey("ToNode")]
        public string ToNodeId { get; set; }
        public virtual Node? FromNode { get; set; }
        public virtual Node? ToNode { get; set; }
        public string Type { get; set; }
        public int Weight { get; set; }

        public NodeLink(string fromNodeId, string toNodeId, string type, int weight)
        {
            FromNodeId = fromNodeId;
            ToNodeId = toNodeId;
            Type = type;
            Weight = weight;
        }
    }
}
