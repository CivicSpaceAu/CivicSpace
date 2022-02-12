﻿using FSH.WebApi.Domain.Common.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Domain.Entities.Content
{
    public class Node : AuditableEntity<string>
    {
        [Required]
        public string Module { get; set; }
        [Required]
        public string Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public string Slug { get; set; }

        // Taxonomy Schemes
        public string Path { get; set; }
        public string ParentId { get; set; }

        [ForeignKey("NodeId")] 
        public NodeCustomFields CustomFields { get; set; }
        [ForeignKey("NodeId")]
        public ICollection<NodeReaction> Reactions { get; set; }
        [ForeignKey("NodeId")]
        public ICollection<NodeTag> Tags { get; set; }
        [ForeignKey("NodeId")]
        public ICollection<NodeVersion> Versions { get; set; }
        [ForeignKey("NodeId")]
        public ICollection<NodeVote> Votes { get; set; }

        // Metrics
        public int Weight { get; set; }
        public int ChildCount { get; set; }
        public int DescendantCount { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        public double Hot { get; set; }

        [NotMapped]
        public string Parent { get; set; }

        [NotMapped]
        public string AllLinks { get; set; } // format: type:link1,link2,...;type:link1,link2,...;...

        [NotMapped]
        public string AllTags { get; set; }

        public int TotalVotes
        {
            get
            {
                var votes = UpVotes - DownVotes;
                return votes > 0 ? votes : 0;
            }
        }
    }
}

public static class StringExt
{
    public static string Truncate(this string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return value.Length <= maxLength ? value : value.Substring(0, maxLength);
    }
}