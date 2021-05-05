using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Chessinator.Application.Dtos;

namespace Chessinator.Application.Interfaces
{
    public interface IPlayerService
    {
        public Task<ParticipantDto> CreatePlayerAsync(ParticipantDto player);

        public Task<bool> DeletePlayerAsync(Guid playerGuid);

        public Task<ParticipantDto> GetPlayerByIdAsync(Guid Id);

        public Task<List<ParticipantDto>> GetPlayersByIdAsync(Guid Id);

        public Task<ParticipantDto> UpdatePlayerAsync(ParticipantDto player);
    }
}

