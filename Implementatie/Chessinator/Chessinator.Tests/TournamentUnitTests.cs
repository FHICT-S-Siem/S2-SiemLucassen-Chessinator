using Chessinator.Application.Dtos;
using Chessinator.Application.Interfaces;
using Chessinator.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

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

        [TestMethod]
        public async Task GetTournament_ReadsTournamentFromDb_ShouldHaveRowsInDb()
        {
            TournamentDto dto = new TournamentDto()
            {
                //Arrange
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
            TournamentDto result = await _tournamentService.GetTournamentByIdAsync(dto.Id);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task UpdateTournament_EditsTournamentInDb_TournamentsAreNotTheSame()
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
            TournamentDto dto2 = new TournamentDto()
            {
                Id = dto.Id,
                UserId = this.UserId,
                Name = "Name2",
                Type = "Swiss",
                Seeding = "Random",
                Time = "Rapid",
                DateTime = DateTime.Now
            };

            //Act
            await _tournamentService.CreateTournamentAsync(dto);
            await _tournamentService.UpdateTournamentAsync(dto2);

            //Assert
            Assert.AreNotEqual(await _tournamentService.GetTournamentByIdAsync(dto2.Id), await _tournamentService.GetTournamentByIdAsync(dto.Id));
        }

        [TestMethod]
        public async Task DeleteTournament_RemovesTournamentFromDb_ShouldHaveNoRowsInDb()
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
            await _tournamentService.CreateTournamentAsync(dto);
            Console.WriteLine(await _tournamentService.GetTournamentByIdAsync(dto.Id)); 
            //Act
            await _tournamentService.DeleteTournamentAsync(dto.Id);

            //Assert
            Assert.IsNull(await _tournamentService.GetTournamentByIdAsync(dto.Id));
        }
    }
}
