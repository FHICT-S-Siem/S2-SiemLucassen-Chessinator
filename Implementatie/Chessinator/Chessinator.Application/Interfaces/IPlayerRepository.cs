using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Chessinator.Application.Dtos;
using Chessinator.Domain.Entities;

namespace Chessinator.Application.Interfaces
{
    public interface IPlayerRepository
    {
        public Task<Player> CreatePlayerAsync(Player player);
        public Task<bool> DeletePlayerAsync(Guid playerGuid);
        public Task<Player> GetPlayerByIdAsync(Guid Id);
        public Task<Player> UpdatePlayerAsync(Player player);
    }
}
