using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Core.Content
{
    public class Node : ModifiableAuditableEntity
    {
        [Key]
        public string Id { get; private set; }
        [Required]
        public string Module { get; private set; }
        [Required]
        public string Type { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string Status { get; private set; }
        public string Slug { get; private set; }

        public string ParentNodeId { get; private set; }
        public string Path { get; private set; }

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

        public Node() : base() { }

        //public Node Update(string slug, string title, string content, string status, string tags)
        //{
        //    if (slug is not null && Slug?.Equals(slug) is not true) Slug = slug;
        //    if (title is not null && Title?.Equals(title) is not true) Title = title;
        //    if (content is not null && Content?.Equals(content) is not true) Content = content;
        //    if (status is not null && Status?.Equals(status) is not true) Status = status;
        //    if (tags is not null) SetTags(tags);
        //    return this;
        //}

        private void SetTags(string tags)
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