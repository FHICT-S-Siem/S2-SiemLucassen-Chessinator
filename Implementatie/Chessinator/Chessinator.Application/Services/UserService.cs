using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chessinator.Application.Dtos;
using Chessinator.Application.Dtos.Responses;
using Chessinator.Application.Interfaces;
using Chessinator.Domain.Entities;

namespace Chessinator.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher _hasher;
        private readonly ISaltGenerator _saltGenerator;
        private readonly IUserRepository _userRepository;

        public UserService(
            IPasswordHasher hasher,
            ISaltGenerator saltGenerator,
            IUserRepository userRepository)
        {
            _hasher = hasher;
            _saltGenerator = saltGenerator;
            _userRepository = userRepository;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
        {
            // Does a user exist with the given credentials?
            User user = await _userRepository.GetUserByUsernameAsync(loginDto.Username);

            if (_hasher.VerifyHash(user.Secret, user.Extra, loginDto.Password))
            {
                return new LoginResponseDto()
                {
                    Success = true,
                    Data = new UserDto()
                    {
                        Id = user.Id,
                        Username = user.Username,
                        Email = user.Email
                    }
                };
            }

            return new LoginResponseDto()
            {
                Success = false
            };
        }
    }
}
