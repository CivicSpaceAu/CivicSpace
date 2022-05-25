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

        public Guid? ParentId { get; private set; }
        public string? Path { get; private set; }

        [ForeignKey("NodeCustomField")]
        public ICollection<NodeCustomField> CustomFields { get; set; } = default!;
        [ForeignKey("NodeLink")]
        public ICollection<NodeLink> Links { get; set; } = default!;
        [ForeignKey("NodeReaction")]
        public ICollection<NodeReaction> Reactions { get; set; } = default!;
        [ForeignKey("NodeTag")]
        public ICollection<NodeTag> Tags { get; set; } = default!;
        [ForeignKey("NodeVote")]
        public ICollection<NodeVote> Votes { get; set; } = default!;

        public Node(string module, string type, string slug, string title, string? content, string status, Guid? parentId, string? path)
        {
            Module = module;
            Type = type;
            Slug = slug;
            Title = title;
            Content = content;
            Status = status;
            ParentId = parentId;
            Path = path;
            Tags = new HashSet<NodeTag>();
        }

        public Node(string module, string type, string slug, string title, string? content, string status, string? customFields, Guid? parentId, string? path, string? tags) :
            this(module, type, slug, title, content, status, parentId, path)
        {
            SetTags(tags);
        }

        public Node Update(string? slug, string? title, string? content, string? status, string? tags)
        {
            if (slug is not null && Slug?.Equals(slug) is not true) Slug = slug;
            if (title is not null && Title?.Equals(title) is not true) Title = title;
            if (content is not null && Content?.Equals(content) is not true) Content = content;
            if (status is not null && Status?.Equals(status) is not true) Status = status;
            if (tags is not null) SetTags(tags);
            return this;
        }

        private void SetTags(string? tags)
        {
            Tags.Clear();
            if (!string.IsNullOrEmpty(tags))
                foreach (string tag in tags.Split(' '))
                {
                    Tags.Add(new NodeTag(Id, tag));
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
