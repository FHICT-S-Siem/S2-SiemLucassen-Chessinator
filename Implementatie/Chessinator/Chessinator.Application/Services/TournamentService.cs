using AutoMapper;
using Chessinator.Application.Dtos;
using Chessinator.Application.Interfaces;
using Chessinator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chessinator.Domain.Exceptions;

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
            if (tournamentDto == null)
                throw new InvalidTournamentException("tournamentDto is null");

            Tournament tournament = _mapper.Map<Tournament>(tournamentDto);

            User trackedUser = await _userRepository.GetUserByIdAsync(tournamentDto.UserId);
            if (trackedUser == null)
                throw new InvalidTournamentException("Failed to get user by id.");

            tournament.User = trackedUser;
            trackedUser.Tournaments.Add(tournament);

            try
            {
                Tournament createdTournament = await _tournamentRepository.CreateTournamentAsync(tournament);
                return _mapper.Map<TournamentDto>(createdTournament);
            }
            catch (Exception)
            {
                throw new InvalidTournamentException("Failed to create tournament");
            }
        }

        public async Task<List<TournamentDto>> GetTournamentsByUserIdAsync(Guid userGuid)
        {
            // tournaments from repository
            List<Tournament> tournaments = await _tournamentRepository.GetTournamentsAsync(userGuid);
            if (tournaments == null)
                throw new InvalidTournamentException("Failed to get any tournaments");
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
            return _mapper.Map<TournamentDto>(tournament);
        }

        public async Task<bool> DeleteTournamentAsync(Guid tournamentId)
        {
            if (tournamentId == Guid.Empty)
            {
                throw new InvalidTournamentException("Failed to delete tournament");
            }
            return await _tournamentRepository.DeleteTournamentAsync(tournamentId);
            
        }

        public async Task<TournamentDto> UpdateTournamentAsync(TournamentDto tournamentDto)
        {
            Tournament tournament =_mapper.Map<Tournament>(tournamentDto);
            Tournament updatedTournament = await _tournamentRepository.UpdateTournamentAsync(tournament);
            if (updatedTournament == null)
                throw new InvalidTournamentException("Failed to update tournament");

            return _mapper.Map<TournamentDto>(updatedTournament);
        }
    }
}
