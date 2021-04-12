using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chessinator.Application.Dtos;

namespace Chessinator.Application.Interfaces
{
    public interface ITournamentService
    {
        /// <summary>
        /// Creates a tournament with the given name.
        /// </summary>
        /// <param name="name">The tournament name.</param>
        /// <returns>Returns the created tournament.</returns>
        public Task<TournamentDto> CreateTournamentAsync(TournamentDto tournament);

        /// <summary>
        /// Gets all tournaments.
        /// </summary>
        /// <returns>Returns a list of tournaments.</returns>
        public Task<List<TournamentDto>> GetTournamentsAsync();

        /// <summary>
        /// Gets a tournament by name.
        /// </summary>
        /// <param name="name">The tournament name.</param>
        /// <returns>Returns a tournament.</returns>
        public Task<TournamentDto> GetTournamentByNameAsync(string tournamentName);

        /// <summary>
        /// Deletes the tournament with the given tournament id.
        /// </summary>
        /// <param name="tournamentId">The tournament id.</param>
        /// <returns>Returns a bool indicating whether the tournament was deleted.</returns>
        public Task<bool> DeleteTournamentAsync(Guid tournamentId);

        /// <summary>
        /// Gets a tournament by Id
        /// </summary>
        /// <param name="tournamentId"></param>
        /// <returns>Returns a tournament by id</returns>
        public Task<TournamentDto> GetTournamentByIdAsync(Guid tournamentId);

        /// <summary>
        /// Updates the tournament.
        /// </summary>
        /// <param name="tournament"></param>
        /// <returns></returns>
        public Task<TournamentDto> UpdateTournamentAsync(TournamentDto tournament);
    }
}
