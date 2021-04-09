using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chessinator.Application.Dtos;
using Chessinator.Application.Dtos.Responses;

namespace Chessinator.Application.Interfaces
{
    public interface IUserService
    {
        public Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
    }
}
