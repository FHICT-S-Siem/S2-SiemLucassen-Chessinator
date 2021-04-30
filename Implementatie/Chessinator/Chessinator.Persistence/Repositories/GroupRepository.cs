using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Chessinator.Application.Interfaces;
using Chessinator.Domain.Entities;
using Chessinator.Persistence.Contexts;

namespace Chessinator.Persistence.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ChessinatorDbContext _chessinatorDbContext;

        public GroupRepository(ChessinatorDbContext chessinatorDbContext)
        {
            _chessinatorDbContext = chessinatorDbContext;
        }

        public Task<Group> CreateGroupAsync(Group group)
        {
            throw new NotImplementedException();
        }

        public Task<List<Group>> GetGroupsByTournamentIdAsync(Guid tournamentGuid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGroupAsync(Guid groupGuid)
        {
            throw new NotImplementedException();
        }

        public Task<Group> UpdateGroupAsync(Group groupDto)
        {
            throw new NotImplementedException();
        }
    }
}
