using Chessinator.Application.Dtos;
using Chessinator.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chessinator.Domain.Entities;

namespace Chessinator.Tests
{
    [TestClass]
    public class TournamentUnitTests : TestBase
    {
        #region fields
        private ITournamentService _tournamentService;
        private IUserRepository _userService;

        public Guid UserId { get; set; }
        //public Guid TournamentId { get; set; }
        #endregion

        [TestInitialize]
        public async Task InitializeAsync()
        {
            InitializeServiceProvider();
            _tournamentService = ServiceProvider.GetService<ITournamentService>();
            _userService = ServiceProvider.GetService<IUserRepository>();

            User user = new User()
            {
                Id = Guid.NewGuid()
            };
            await _userService.CreateUserAsync(user);
            UserId = user.Id;
            //TournamentId = tournament.Id;
        }

        [TestMethod]
        public async Task CreateTournament_AddsTournamentToDb_ShouldHaveTournamentInDb()
        {
            //Arrange
            TournamentDto dto = new TournamentDto()
            {
                Id = Guid.NewGuid(),
                UserId = this.UserId,
                Name = "Name",
                Type = "Survival",
                Seeding = "Custom",
                Time = "Blitz",
                DateTime = DateTime.Now
            };

            //Act
            await _tournamentService.CreateTournamentAsync(dto);

            //Assert
            Assert.IsNotNull(await _tournamentService.GetTournamentByIdAsync(dto.Id));
        }
    }
}
