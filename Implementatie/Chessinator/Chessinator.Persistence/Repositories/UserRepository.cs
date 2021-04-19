using Chessinator.Application.Interfaces;
using Chessinator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chessinator.Application.Dtos;
using Chessinator.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Chessinator.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ChessinatorDbContext _dbContext;

        public UserRepository(ChessinatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _dbContext.Users.Where(user => user.Username == username).FirstOrDefaultAsync();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            EntityEntry<User> trackedUser = await _dbContext.Users.AddAsync(user);
            int recordsChanged = await _dbContext.SaveChangesAsync();
            return recordsChanged > 0 
                ? trackedUser.Entity 
                : null;
        }

        public async Task<bool> UsernameAlreadyExistAsync(string username)
        {
            return await _dbContext.Users.AnyAsync(user => user.Username == username);
            
        }
    }
}
