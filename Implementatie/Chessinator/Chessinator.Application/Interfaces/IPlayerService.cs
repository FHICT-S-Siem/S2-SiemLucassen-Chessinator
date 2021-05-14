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

        public Task<List<ParticipantDto>> GetPlayersByTournamentIdAsync(Guid tournamentId);

        public Task<bool> DoesPlayerExist(string name);

        public Task<bool> DeletePlayerAsync(Guid id);

        public Task<ParticipantDto> GetPlayerByIdAsync(Guid id);


        public Task<ParticipantDto> UpdatePlayerAsync(ParticipantDto player);
    }
}

