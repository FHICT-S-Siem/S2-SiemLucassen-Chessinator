using System;
using System.IO;
using Chessinator.Domain.Entities;
using Chessinator.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Chessinator.Persistence.Contexts
{
    public class ChessinatorDbContext : DbContext
    {
        /// <summary>
        /// Get & sets the tournaments (Tournaments table).
        /// </summary>
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<User> Users { get; set; }

        public ChessinatorDbContext(DbContextOptions<ChessinatorDbContext> options) : base(options)
        {
            
        }

        public ChessinatorDbContext()
        {
                
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer(connection);
        //    //optionsBuilder.UseSqlite(@"Data Source=C:\Users\siem\Desktop\Fontys\Semester 2\S-DB-S2-CMK\S2-SiemLucassen-Chessinator\Implementatie\Tournaments.db");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configures the Data constraints on the Entities.
            modelBuilder.ApplyConfiguration(new TournamentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class BloggingContextFactory : IDesignTimeDbContextFactory<ChessinatorDbContext>
    {
        public ChessinatorDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChessinatorDbContext>();
            string connection = ConfigurationLoader.GetConfiguration("appsettings")["ConnectionStrings:DefaultConnection"];

            optionsBuilder.UseSqlServer(connection);

            return new ChessinatorDbContext(optionsBuilder.Options);
        }
    }

    /// <summary>
    /// Represents the <see cref="ConfigurationLoader"/> class.
    /// </summary>
    public static class ConfigurationLoader
    {
        private static IConfiguration _currentConfiguration;

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <param name="configuration">The configuration file name.</param>
        /// <returns>Returns the <see cref="IConfiguration"/>.</returns>
        public static IConfiguration GetConfiguration(string configuration)
        {
            if (_currentConfiguration != null)
                return _currentConfiguration;
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            string basePath = Directory.GetCurrentDirectory();
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile($"{configuration}.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"{configuration}.{env}.json", optional: true, reloadOnChange: false);
            return _currentConfiguration = builder.Build();
        }
    }
}
