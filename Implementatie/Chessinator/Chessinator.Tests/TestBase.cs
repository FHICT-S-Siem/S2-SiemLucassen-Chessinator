using Chessinator.Application.Cryptography;
using Chessinator.Application.Interfaces;
using Chessinator.Application.Services;
using Chessinator.Persistence.Contexts;
using Chessinator.Persistence.Repositories;
using Chessinator.Presentation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Chessinator.Tests
{
    /// <summary>
    ///  Initializes the services for the tests.
    /// </summary>
    public abstract class TestBase
    {
        protected ServiceProvider ServiceProvider;
        protected void InitializeServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddAutoMapper(typeof(Startup));
            services.AddOptions();
            
            //Creates Temporary database in memory for testing.
            services.AddDbContext<ChessinatorDbContext>(options => options.UseInMemoryDatabase(databaseName: "TestDb"));
            services.AddLogging(loginBuilder => loginBuilder.AddConsole());
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ISaltGenerator, RandomSaltGenerator>();

            // Adds the repositories with their interfaces.
            services.AddScoped<ITournamentRepository, TournamentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();

            // Adds the services with their interfaces.
            services.AddScoped<ITournamentService, TournamentService>();
            services.AddScoped<IUserService, UserService>();

            ServiceProvider = services.BuildServiceProvider();
            ChessinatorDbContext dbContext = ServiceProvider.GetService<ChessinatorDbContext>();
            dbContext.Database.EnsureCreated();
        }
    }
}
