using Chessinator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chessinator.Persistence.Configurations
{
    public class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.TournamentName).HasMaxLength(64).IsRequired();
            builder.Property(p => p.TournamentSeeding).IsRequired();
            builder.Property(p => p.TournamentTime).IsRequired();
            builder.Property(p => p.TournamentType).IsRequired();
            builder.Property(p => p.TournamentDatetime).IsRequired();
        }
    }
}
