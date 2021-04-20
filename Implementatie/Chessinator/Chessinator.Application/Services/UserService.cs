using AutoMapper;
using Chessinator.Application.Dtos;
using Chessinator.Application.Dtos.Responses;
using Chessinator.Application.Interfaces;
using Chessinator.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Chessinator.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher _hasher;
        private readonly ISaltGenerator _saltGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;


        public UserService(
            IPasswordHasher hasher,
            ISaltGenerator saltGenerator,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _hasher = hasher;
            _saltGenerator = saltGenerator;
            _userRepository = userRepository;
            _mapper = mapper;
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

        public async Task<SimpleResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            bool success = false;
            // Does username already exist?
            bool userExists = await _userRepository.UsernameAlreadyExistAsync(registerDto.Username);
            
            if (!userExists)
            {
                byte[] salt = _saltGenerator.GenerateSalt();

                User user = new User
                {
                    Username = registerDto.Username,
                    Email = registerDto.Email,
                    Secret = _hasher.Hash(registerDto.Password, salt),
                    Extra = Convert.ToBase64String(salt),
                    Country = registerDto.Country
                };

                // Create user
                User createdUser = await _userRepository.CreateUserAsync(user);
                success = createdUser != null;
            }
            return new SimpleResponseDto()
            {
                Success = success
            };
        }
    }
}
