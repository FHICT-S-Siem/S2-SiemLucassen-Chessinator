using Chessinator.Application.Dtos;
using Chessinator.Application.Interfaces;
using Chessinator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Chessinator.Application.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;

        public TournamentService(
            ITournamentRepository tournamentRepository,
            IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }

        public async Task<TournamentDto> CreateTournamentAsync(TournamentDto tournamentDto)
        {
            Tournament tournament = _mapper.Map<Tournament>(tournamentDto);
            Tournament createdTournament = await _tournamentRepository.CreateTournamentAsync(tournament);

            if (createdTournament == null)
                throw new Exception("Failed to create tournament");

            return _mapper.Map<TournamentDto>(createdTournament);
        }

        public async Task<List<TournamentDto>> GetTournamentsAsync()
        {

            // tournaments from repository
            List<Tournament> tournaments = await _tournamentRepository.GetTournamentsAsync();

            // map tournament ENTITY to tournament DTO!!
            List<TournamentDto> tournamentDtos = tournaments.Select(ToTournamentDto).ToList();

            return tournamentDtos;

            // mapping function to map entity to dto
            static TournamentDto ToTournamentDto(Tournament tournament)
            {
                return new TournamentDto()
                {
                    Id = tournament.Id,
                    Name = tournament.Name,
                    Type = tournament.Type,
                    Seeding = tournament.Seeding,
                    Time = tournament.Time,
                    Datetime = tournament.Datetime
                };
            }
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
