using Chessinator.Domain.Entities;
using Chessinator.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Chessinator.Persistence.Contexts
{
    public class ChessinatorDbContext : DbContext
    {
        /// <summary>
        /// Get & sets the tournaments (Tournaments table).
        /// </summary>
        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
            //optionsBuilder.UseSqlite(@"Data Source=C:\Users\siem\Desktop\Fontys\Semester 2\S-DB-S2-CMK\S2-SiemLucassen-Chessinator\Implementatie\Tournaments.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configures the Data constraints on the Entities.
            modelBuilder.ApplyConfiguration(new TournamentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
