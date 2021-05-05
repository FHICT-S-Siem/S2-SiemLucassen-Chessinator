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

        public Task<bool> DeletePlayerAsync(Guid playerGuid)
        {
            throw new NotImplementedException();
        }

        public Task<ParticipantDto> GetPlayerByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<ParticipantDto> UpdatePlayerAsync(ParticipantDto player)
        {
            throw new NotImplementedException();
        }
    }
}
