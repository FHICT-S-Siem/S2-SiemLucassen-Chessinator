using Chessinator.Application.Interfaces;
using Chessinator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chessinator.Application.Dtos;
using Chessinator.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

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
    }
}
