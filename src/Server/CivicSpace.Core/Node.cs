using CivicSpace.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace CivicSpace.Core
{
    public class Node : ModifiableEntity
    {
        [Required]
        public string Tenant { get; set; } = string.Empty;
        [Required]
        public string Module { get; set; } = string.Empty;
        [Required]
        public string Type { get; set; } = string.Empty;
        public string ParentId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public List<string> Tags { get; set; }
        public Dictionary<string, string> Links { get; set; }
        public Dictionary<string, string> Reactions { get; set; }
        public Dictionary<string, int> Votes { get; set; }
        public int TotalVotes { get; set; }
        public int Score { get; set; }
        public string Metadata { get; set; } = string.Empty;

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
        }
    }
}