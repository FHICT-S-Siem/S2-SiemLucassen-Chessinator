using AutoMapper;
using Chessinator.Application.Dtos;
using Chessinator.Application.Dtos.Responses;
using Chessinator.Application.Interfaces;
using Chessinator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chessinator.Domain.Exceptions;

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

        public async Task<bool> DeleteUserAsync(Guid userGuid)
        {
            return await _userRepository.DeleteUserAsync(userGuid);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            List<User> users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByUserIdAsync(Guid userGuid)
        {
            User user = await _userRepository.GetUserByIdAsync(userGuid);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
        {
            // Does a user exist with the given credentials?
            User user;
            user = await _userRepository.GetUserByUsernameAsync(loginDto.Username);
            
            if (user == null)
            {
                return new LoginResponseDto()
                {
                    Success = false,
                    Message = "Invalid username or password"
                };
            }

            if (user.UserStatus == "Active")
            {
                if (_hasher.VerifyHash(user.Secret, user.Extra, loginDto.Password))
                {
                    return new LoginResponseDto()
                    {
                        Success = true,
                        Data = _mapper.Map<UserDto>(user)
                    };
                }
            }
            else if (user.UserStatus == "Suspended")
            {
                return new LoginResponseDto()
                {
                    Success = false,
                    Message = "You have been suspended from Chessinator."
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

        public async Task<UserDto> SuspendUserAsync(UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            User updatedUser = await _userRepository.SuspendUserAsync(user);

            if (updatedUser == null)
                throw new ChessinatorException("Failed to suspend user");

            return _mapper.Map<UserDto>(updatedUser);
        }

        public async Task<UserDto> UnsuspendUserAsync(UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            User updatedUser = await _userRepository.UnsuspendUserAsync(user);

            if (updatedUser == null)
                throw new ChessinatorException("Failed to suspend user");

            return _mapper.Map<UserDto>(updatedUser);
        }

        public async Task<UserDto> UpdateUserAsync(UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            User updatedUser = await _userRepository.UpdateUserAsync(user);

            if (updatedUser == null)
                throw new ChessinatorException("Failed to update user");

            return _mapper.Map<UserDto>(updatedUser);
        }
    }
}
