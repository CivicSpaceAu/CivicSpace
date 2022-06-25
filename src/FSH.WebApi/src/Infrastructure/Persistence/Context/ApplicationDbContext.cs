using CivicSpace.Domain.Entities.Content;
using Finbuckle.MultiTenant;
using FSH.WebApi.Application.Common.Events;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FSH.WebApi.Infrastructure.Persistence.Context;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(ITenantInfo currentTenant, DbContextOptions options, ICurrentUser currentUser, ISerializerService serializer, IOptions<DatabaseSettings> dbSettings, IEventService eventService)
        : base(currentTenant, options, currentUser, serializer, dbSettings, eventService)
    {
    }

    public DbSet<Node> Nodes => Set<Node>();
    public DbSet<NodeLink> NodeLinks => Set<NodeLink>();
    public DbSet<NodeReaction> NodeReactions => Set<NodeReaction>();
    public DbSet<NodeVote> NodeVotes => Set<NodeVote>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Node>()
            .HasMany(n => n.CustomFields)
            .WithOne(ncf => ncf.Node);

        modelBuilder.Entity<Node>()
            .HasMany(n => n.Links)
            .WithOne(nl => nl.Node);

        modelBuilder.Entity<Node>()
            .HasMany(n => n.Reactions)
            .WithOne(nr => nr.Node);

        modelBuilder.Entity<Node>()
            .HasMany(n => n.Tags)
            .WithOne(nt => nt.Node);

        modelBuilder.Entity<Node>()
            .HasMany(n => n.Votes)
            .WithOne(nv => nv.Node);

        modelBuilder.HasDefaultSchema(SchemaNames.Catalog);
    }
}