using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chessinator.Application.Interfaces;
using Chessinator.Domain.Entities;
using Chessinator.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Chessinator.Persistence.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ChessinatorDbContext _chessinatorDbContext;

        public PlayerRepository(ChessinatorDbContext chessinatorDbContext)
        {
            _chessinatorDbContext = chessinatorDbContext;
        }

        public async Task<Player> CreatePlayerAsync(Player player)
        {
            EntityEntry<Player> trackedPlayer = await _chessinatorDbContext.Players.AddAsync(player);
            await _chessinatorDbContext.SaveChangesAsync();
            return trackedPlayer.Entity;
        }

        public async Task<bool> DeletePlayerAsync(Guid id)
        {
            Player trackedPlayer = await _chessinatorDbContext.Players.FindAsync(id);
            _chessinatorDbContext.Players.Remove(trackedPlayer);
            int rowsChanged = await _chessinatorDbContext.SaveChangesAsync();
            return rowsChanged > 0;
        }

        public async Task<bool> DoesPlayerExist(string name)
        {
            // Checks if any player name already exists. returns true if the name exists, else false
            return await _chessinatorDbContext.Players.AnyAsync(p => p.Name == name);
        }

        public async Task<Player> GetPlayerByIdAsync(Guid Id)
        {
            return await _chessinatorDbContext.Players.FindAsync(Id);
        }

        public async Task<List<Player>> GetPlayersByTournamentIdAsync(Guid tournamentId)
        {
            return await _chessinatorDbContext.Players.Where(p => p.TournamentId == tournamentId).ToListAsync();
        }

        public Task<Player> UpdatePlayerAsync(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
