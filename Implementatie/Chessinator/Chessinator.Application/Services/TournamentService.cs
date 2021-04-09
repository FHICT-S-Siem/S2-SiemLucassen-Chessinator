using Chessinator.Application.Dtos;
using Chessinator.Application.Interfaces;
using Chessinator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chessinator.Application.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;

        public TournamentService(
            ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public async Task<TournamentDto> CreateTournamentAsync(string tournamentName)
        {
            Tournament tournament = new Tournament()
            {
                // TODO: Alles meegeven?
                TournamentName = tournamentName
            };
            Tournament createdTournament = await _tournamentRepository.CreateTournamentAsync(tournament);

            if (createdTournament == null)
                throw new Exception("Failed to create tournament");

            TournamentDto tournamentDto = new TournamentDto
            {
                TournamentName = createdTournament.TournamentName
            };

            return tournamentDto;
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
                    TournamentName = tournament.TournamentName
                };
            }
        }

        public async Task<TournamentDto> GetTournamentByNameAsync(string tournamentName)
        {
            Tournament tournament = await _tournamentRepository.GetTournamentByNameAsync(tournamentName);
            TournamentDto tournamentDto = new TournamentDto()
            {
                TournamentName = tournament.TournamentName
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

        public async Task<TournamentDto> UpdateTournamentAsync(TournamentDto tournament)
        {
            // TODO: Update tournament.
            throw new NotImplementedException();
        }
    }
}
