using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Chessinator.Application.Dtos;
using Chessinator.Application.Interfaces;
using Chessinator.Domain.Entities;

namespace Chessinator.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }
        public async Task<ParticipantDto> CreatePlayerAsync(ParticipantDto participantDto)
        {
            Player player = _mapper.Map<Player>(participantDto);
            Player createdPlayer = await _playerRepository.CreatePlayerAsync(player);

            if (createdPlayer == null)
                throw new Exception("Failed to create player");
            return _mapper.Map<ParticipantDto>(createdPlayer);
        }

        public async Task<bool> DeletePlayerAsync(Guid id)
        {
            return await _playerRepository.DeletePlayerAsync(id);

        }

        public async Task<bool> DoesPlayerExist(string name)
        {
            return await _playerRepository.DoesPlayerExist(name);
        }

        public Task<ParticipantDto> GetPlayerByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ParticipantDto>> GetPlayersByTournamentIdAsync(Guid tournamentId)
        {
            List<Player> players = await _playerRepository.GetPlayersByTournamentIdAsync(tournamentId);

            return _mapper.Map<List<ParticipantDto>>(players);
        }

        public Task<ParticipantDto> UpdatePlayerAsync(ParticipantDto player)
        {
            throw new NotImplementedException();
        }
    }
}
