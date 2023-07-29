using CivicSpace.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivicSpace.Core.Content
{
    public class Node : ModifiableEntity
    {
        [Required]
        public string Tenant { get; set; } = string.Empty;
        [Required]
        public string Module { get; set; } = string.Empty;
        [Required]
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;

        public string ParentNodeId { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;

        [NotMapped]
        public string MetadataJson { get; set; } = string.Empty;

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

        public void Copy(Node node)
        {
            Tenant = node.Tenant;
            Module = node.Module;
            Type = node.Type;
            Title = node.Title;
            Content = node.Content;
            Status = node.Status;
            Slug = node.Slug;
            ParentNodeId = node.ParentNodeId;
            Path = node.Path;
        }
            
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