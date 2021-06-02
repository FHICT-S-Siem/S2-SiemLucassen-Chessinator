using System;
using System.Collections.Generic;
using Chessinator.Application.Dtos;
using Chessinator.Application.Dtos.Responses;
using System.Threading.Tasks;

namespace Chessinator.Application.Interfaces
{
    public interface IUserService
    {
        public Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
        public Task<SimpleResponseDto> RegisterAsync(RegisterDto registerDto);
        public Task<UserDto> GetUserByUserIdAsync(Guid userGuid);
        public Task<List<UserDto>> GetAllUsersAsync();
        public Task<bool> DeleteUserAsync(Guid userGuid);
        public Task<UserDto> UpdateUserAsync(UserDto user);
        public Task<UserDto> SuspendUserAsync(UserDto user);
        public Task<UserDto> UnsuspendUserAsync(UserDto user);
    }
}
