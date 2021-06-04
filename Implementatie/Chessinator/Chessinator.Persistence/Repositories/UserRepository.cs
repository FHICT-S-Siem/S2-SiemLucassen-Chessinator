using Chessinator.Application.Interfaces;
using Chessinator.Domain.Entities;
using Chessinator.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
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

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();

        }

        public async Task<User> UpdateUserAsync(User user)
        {
            User trackedUser = await _dbContext.Users.FindAsync(user.Id);

            if (trackedUser != null)
            {
                trackedUser.Username = user.Username;
                trackedUser.Email = user.Email;
                trackedUser.Country = user.Country;
                //trackedUser.Role = user.Role;
                //trackedUser.Secret = user.Secret;
                //trackedUser.UserStatus = user.UserStatus;
                //trackedUser.Tournaments = user.Tournaments;

                await _dbContext.SaveChangesAsync();
            }

            return trackedUser;
        }
        public async Task<bool> DeleteUserAsync(Guid userGuid)
        {
            User trackedUser = await _dbContext.Users.FindAsync(userGuid);
            _dbContext.Users.Remove(trackedUser);
            int rowsChanged = await _dbContext.SaveChangesAsync();
            return rowsChanged > 0;
        }
        public async Task<User> SuspendUserAsync(User user)
        {
            User trackedUser = await _dbContext.Users.FindAsync(user.Id);

            if (trackedUser != null)
            {
                trackedUser.UserStatus = "Suspended";

                await _dbContext.SaveChangesAsync();
            }

            return trackedUser;
        }
        public async Task<User> UnsuspendUserAsync(User user)
        {
            User trackedUser = await _dbContext.Users.FindAsync(user.Id);

            if (trackedUser != null)
            {
                trackedUser.UserStatus = "Active";

                await _dbContext.SaveChangesAsync();
            }

            return trackedUser;
        }
    }
}
