using CivicSpace.Domain.Entities.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CivicSpace.Infrastructure.Persistence.Configuration;

public class NodeConfig : IEntityTypeConfiguration<Node>
{
    public void Configure(EntityTypeBuilder<Node> builder)
    {
        throw new NotImplementedException();
    }
}