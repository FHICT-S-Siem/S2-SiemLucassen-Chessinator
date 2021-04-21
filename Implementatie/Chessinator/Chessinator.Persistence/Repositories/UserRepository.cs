using Chessinator.Application.Interfaces;
using Chessinator.Domain.Entities;
using Chessinator.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await _dbContext.Users.FindAsync(userId);
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
