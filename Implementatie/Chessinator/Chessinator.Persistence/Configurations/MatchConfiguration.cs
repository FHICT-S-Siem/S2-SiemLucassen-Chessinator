using Chessinator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chessinator.Persistence.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IsPlayed);
            builder.Property(p => p.Winner);

            // Many Matches have many Players.  
            builder
                .HasMany(p => p.Players)
                .WithMany(p => p.Matches);
        }
    }
}
