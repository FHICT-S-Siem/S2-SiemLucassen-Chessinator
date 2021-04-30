using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Chessinator.Domain.Entities;

namespace Chessinator.Application.Interfaces
{
    public interface IGroupRepository
    {
        public Task<Group> CreateGroupAsync(Group group);

        public Task<List<Group>> GetGroupsByTournamentIdAsync(Guid tournamentGuid);

        public Task<bool> DeleteGroupAsync(Guid groupGuid);

        public Task<Group> UpdateGroupAsync(Group groupDto);
    }
}
