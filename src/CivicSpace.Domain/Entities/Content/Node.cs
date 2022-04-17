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

        public Guid? ParentId { get; private set; }
        public string? Path { get; private set; }

        [ForeignKey("NodeTag")]
        public ICollection<NodeTag> Tags { get; set; }
        [ForeignKey("NodeMetric")]
        public ICollection<NodeMetric> Metrics { get; set; }

        public Node(string module, string type, string slug, string title, string? content, string status, string? customFields, Guid? parentId, string? path)
        {
            Module = module;
            Type = type;
            Slug = slug;
            Title = title;
            Content = content;
            Status = status;
            CustomFields = customFields;
            ParentId = parentId;
            Path = path;
            Tags = new HashSet<NodeTag>();
            Metrics = new HashSet<NodeMetric>();
        }

        public Node(string module, string type, string slug, string title, string? content, string status, string? customFields, Guid? parentId, string? path, string? tags) :
            this(module, type, slug, title, content, status, customFields, parentId, path)
        {
            SetTags(tags);
        }

        public Node Update(string? slug, string? title, string? content, string? status, string? customFields, string? tags)
        {
            if (slug is not null && Slug?.Equals(slug) is not true) Slug = slug;
            if (title is not null && Title?.Equals(title) is not true) Title = title;
            if (content is not null && Content?.Equals(content) is not true) Content = content;
            if (status is not null && Status?.Equals(status) is not true) Status = status;
            if (customFields is not null && CustomFields?.Equals(customFields) is not true) CustomFields = customFields;
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
