using Chessinator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chessinator.Persistence.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Participant).IsRequired();
            builder.Property(p => p.Groups).IsRequired();
            builder.Property(p => p.GroupSize).IsRequired();

            // Many Groups have many Players
            builder
                .HasMany(p => p.Players)
                .WithMany(p => p.Groups);

        }
    }
}
