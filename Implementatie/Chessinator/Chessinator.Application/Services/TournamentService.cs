using AutoMapper;
using Chessinator.Application.Dtos;
using Chessinator.Application.Interfaces;
using Chessinator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chessinator.Application.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public TournamentService(
            ITournamentRepository tournamentRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<TournamentDto> CreateTournamentAsync(TournamentDto tournamentDto)
        {
            // Map from DTO,
            // problem here is that the user that is mapped already exists in the database, so
            // we have to get the tracked user from the database and set the tournament user to be the tracked user.
            Tournament tournament = _mapper.Map<Tournament>(tournamentDto);

            User trackedUser = await _userRepository.GetUserByIdAsync(tournamentDto.UserId);
            tournament.User = trackedUser;
            trackedUser.Tournaments.Add(tournament);

            Tournament createdTournament = await _tournamentRepository.CreateTournamentAsync(tournament);

            if (createdTournament == null)
                throw new Exception("Failed to create tournament");

            return _mapper.Map<TournamentDto>(createdTournament);
        }

        public async Task<List<TournamentDto>> GetTournamentsByUserIdAsync(Guid userGuid)
        {
            // tournaments from repository
            List<Tournament> tournaments = await _tournamentRepository.GetTournamentsAsync(userGuid);

            // map tournament ENTITY to tournament DTO
            return _mapper.Map<List<TournamentDto>>(tournaments);
        }

        public async Task<TournamentDto> GetTournamentByNameAsync(string Name)
        {
            Tournament tournament = await _tournamentRepository.GetTournamentByNameAsync(Name);
            TournamentDto tournamentDto = new TournamentDto()
            {
                Name = tournament.Name
            };
            return tournamentDto;
        }

        public async Task<TournamentDto> GetTournamentByIdAsync(Guid tournamentId)
        {
            Tournament tournament = await _tournamentRepository.GetTournamentByIdAsync(tournamentId);
            TournamentDto tournamentDto = new TournamentDto()
            {
                Id = tournament.Id
            };
            return tournamentDto;
        }

        public async Task<bool> DeleteTournamentAsync(Guid tournamentId)
        { 
            return await _tournamentRepository.DeleteTournamentAsync(tournamentId);
        }

        public async Task<TournamentDto> UpdateTournamentAsync(TournamentDto tournamentDto)
        {
            Tournament tournament =_mapper.Map<Tournament>(tournamentDto);
            Tournament updatedTournament = await _tournamentRepository.UpdateTournamentAsync(tournament);

            if (updatedTournament == null)
                throw new Exception("Failed to update tournament");

            return _mapper.Map<TournamentDto>(updatedTournament);
        }
    }
}
