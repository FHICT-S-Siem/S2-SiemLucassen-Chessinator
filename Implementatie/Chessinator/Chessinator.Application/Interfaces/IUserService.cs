using Chessinator.Application.Dtos;
using Chessinator.Application.Dtos.Responses;
using System.Threading.Tasks;

namespace Chessinator.Application.Interfaces
{
    public interface IUserService
    {
        public Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
        public Task<SimpleResponseDto> RegisterAsync(RegisterDto registerDto);
    }
}
