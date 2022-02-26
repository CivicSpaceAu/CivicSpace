using FSH.WebApi.Domain.Common.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Domain.Entities.Content
{
    public class Node : AuditableEntity, IAggregateRoot
    {
        [Required]
        public string Module { get; private set; }
        [Required]
        public string Type { get; private set; }
        public string Title { get; private set; }
        public string? Content { get; private set; }
        public string Status { get; private set; }
        public string Slug { get; private set; }
        public string? CustomFields { get; private set; }

        // Taxonomy Schemes
        public string? ParentId { get; private set; }
        public string? Path { get; private set; }

        [ForeignKey("NodeId")]
        public ICollection<NodeReaction> Reactions { get; set; }
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

        public int TotalVotes
        {
            get
            {
                var votes = UpVotes - DownVotes;
                return votes > 0 ? votes : 0;
            }
        }

        public Node(string module, string type, string slug, string title, string? content, string status, string? customFields)
        {
            Module = module;
            Type = type;
            Slug = slug;
            Title = title;
            Content = content;
            Status = status;
            CustomFields = customFields;
        }

        public Node Update(string? slug, string? title, string? content, string? status, string? customFields)
        {
            if (slug is not null && Slug?.Equals(slug) is not true) Slug = slug;
            if (title is not null && Title?.Equals(title) is not true) Title = title;
            if (content is not null && Content?.Equals(content) is not true) Content = content;
            if (status is not null && Status?.Equals(status) is not true) Status = status;
            if (customFields is not null && CustomFields?.Equals(customFields) is not true) CustomFields = customFields;
            return this;
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
