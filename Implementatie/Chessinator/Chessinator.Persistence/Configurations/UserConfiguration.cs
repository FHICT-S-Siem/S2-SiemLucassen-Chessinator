using Chessinator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chessinator.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Username).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(64).IsRequired();
            builder.Property(p => p.Country).IsRequired();
            builder.Property(p => p.Secret).IsRequired();
            builder.Property(p => p.Extra).IsRequired();
            builder.Property(p => p.Role).HasDefaultValue("User").IsRequired();
            builder.Property(p => p.UserStatus).HasDefaultValue("Active").IsRequired();
        }
    }
}
