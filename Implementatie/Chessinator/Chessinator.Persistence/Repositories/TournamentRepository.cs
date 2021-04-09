using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chessinator.Application.Interfaces;
using Chessinator.Domain.Entities;
using Chessinator.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Chessinator.Persistence.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly ChessinatorDbContext _chessinatorDbContext;

        public TournamentRepository(ChessinatorDbContext chessinatorDbContext)
        {
            _chessinatorDbContext = chessinatorDbContext;
        }

        /// <summary>
        /// Adds tournament to database.
        /// </summary>
        /// <param name="tournament">The tournament</param>
        /// <returns>Returns the tracked tournament</returns>
        public async Task<Tournament> CreateTournamentAsync(Tournament tournament)
        {
            EntityEntry<Tournament> trackedTournament = await _chessinatorDbContext.Tournaments.AddAsync(tournament);
            await _chessinatorDbContext.SaveChangesAsync();
            return trackedTournament.Entity;
        }

        public async Task<bool> DeleteTournamentAsync(Guid tournamentId)
        {
            Tournament trackedTournament = await _chessinatorDbContext.Tournaments.FindAsync(tournamentId);
            _chessinatorDbContext.Tournaments.Remove(trackedTournament);
            int rowsChanged = await _chessinatorDbContext.SaveChangesAsync();
            return rowsChanged > 0;

        }

        public async Task<Tournament> GetTournamentByIdAsync(Guid tournamentId)
        {
            return await _chessinatorDbContext.Tournaments.FindAsync(tournamentId);
        }

        public async Task<Tournament> GetTournamentByNameAsync(string tournamentName)
        {
            return await _chessinatorDbContext.Tournaments.FindAsync(tournamentName);
        }

        public async Task<List<Tournament>> GetTournamentsAsync()
        {
            return await _chessinatorDbContext.Tournaments.ToListAsync();
        }

        public Task<Tournament> UpdateTournamentAsync(Tournament tournament)
        {
            // TODO: Update tournament Async.
            throw new NotImplementedException();
        }
    }
}
