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

        public Task<bool> DeletePlayerAsync(Guid playerGuid)
        {
            throw new NotImplementedException();
        }

        public async Task<Player> GetPlayerByIdAsync(Guid Id)
        {
            return await _chessinatorDbContext.Players.FindAsync(Id);
        }

        public Task<List<Player>> GetPlayersByTournamentIdAsync(Guid tournamentId)
        {
            throw new NotImplementedException();
            //return await _chessinatorDbContext.Players.Where(t => t.TournamentId == tournamentId).ToListAsync();

        }

        public Task<Player> UpdatePlayerAsync(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
