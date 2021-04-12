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
            builder.Property(p => p.Name).HasMaxLength(64).IsRequired();
            builder.Property(p => p.Seeding).IsRequired();
            builder.Property(p => p.Time).IsRequired();
            builder.Property(p => p.Type).IsRequired();
            builder.Property(p => p.Datetime).IsRequired().HasDefaultValueSql("getdate()");
        }
    }
}
