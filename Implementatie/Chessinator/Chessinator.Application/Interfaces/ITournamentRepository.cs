using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chessinator.Domain.Entities;

namespace Chessinator.Application.Interfaces
{
    public interface ITournamentRepository
    {
        /// <summary>
        /// Creates a tournament entity in the database.
        /// </summary>
        /// <param name="tournament">The tournament entity.</param>
        /// <returns>Returns a boolean indicating whether the tournament was created.</returns>
        public Task<Tournament> CreateTournamentAsync(Tournament tournament);

        /// <summary>
        /// Gets a tournament by name.
        /// </summary>
        /// <param name="tournamentName">The tournament name.</param>
        /// <returns>Returns a tournament by name</returns>
        public Task<Tournament> GetTournamentByNameAsync(string tournamentName);

        /// <summary>
        /// Gets the tournaments.
        /// </summary>
        /// <returns>Returns a list of tournaments.</returns>
        public Task<List<Tournament>> GetTournamentsAsync();

        /// <summary>
        /// Deletes a tournament with the given id.
        /// </summary>
        /// <param name="tournamentId">The tournament id.</param>
        /// <returns>Returns a bool indicating whether the tournament was deleted.</returns>
        public Task<bool> DeleteTournamentAsync(Guid tournamentId);

        /// <summary>
        /// Gets a tournament by Id
        /// </summary>
        /// <param name="tournamentId"></param>
        /// <returns>Returns a tournament by id</returns>
        public Task<Tournament> GetTournamentByIdAsync(Guid tournamentId);

        /// <summary>
        /// Updates the tournament.
        /// </summary>
        /// <param name="tournament"></param>
        /// <returns></returns>
        public Task<Tournament> UpdateTournamentAsync(Tournament tournament);
    }
}
