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
    public class UserUnitTests : TestBase
    {
        #region Fields
        private IUserRepository _userRepository;
        private IUserService _userService;

        public Guid UserId { get; set; }
        #endregion

        [TestInitialize]
        public async Task InitializeAsync()
        {
            InitializeServiceProvider();
            _userRepository = ServiceProvider.GetService<IUserRepository>();
            _userService = ServiceProvider.GetService<IUserService>();

            User user = new User()
            {
                Id = Guid.NewGuid()
            };
            await _userRepository.CreateUserAsync(user);
            UserId = user.Id;
        }

        [TestMethod]
        public async Task CreateUser_AddsUserToDb_ShouldHaveUserInDb()
        {
            //Arrange
            RegisterDto dto = new RegisterDto()
            {
                Id = Guid.NewGuid(),
                Username = "Name",
                Email = "Test@gmail.com",
                Password = "Password",
                Country = "Netherlands"
            };

            User dto2 = new User()
            {
                Id = dto.Id
            };

            //Act
            await _userService.RegisterAsync(dto);

            //Assert
            Assert.IsNotNull(await _userRepository.GetUserByIdAsync(dto2.Id));

        }
    }
}
