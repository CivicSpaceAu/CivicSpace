﻿using FSH.WebApi.Domain.Common.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Domain.Entities.Content
{
    public class NodeTag : AuditableEntity<string>
    {
        [ForeignKey("Node")]
        public string NodeId { get; set; }
        public Node Node { get; set; }
        public string Tag { get; set; }
    }
}
