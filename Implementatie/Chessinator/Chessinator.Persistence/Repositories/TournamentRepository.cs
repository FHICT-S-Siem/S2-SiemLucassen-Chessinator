﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<List<Tournament>> GetTournamentsAsync(Guid userGuid)
        {
            return await _chessinatorDbContext.Tournaments.Where(t => t.UserId == userGuid).ToListAsync();
        }
        public async Task<Tournament> UpdateTournamentAsync(Tournament tournament)
        {
            Tournament trackedTournament =  await _chessinatorDbContext.Tournaments.FindAsync(tournament.Id);

            if (trackedTournament != null)
            {
                trackedTournament.Name = tournament.Name;
                trackedTournament.Seeding = tournament.Seeding;
                trackedTournament.Time = tournament.Time;
                trackedTournament.Type = tournament.Type;

                await _chessinatorDbContext.SaveChangesAsync();
            }

            return trackedTournament;
        }
    }
}
