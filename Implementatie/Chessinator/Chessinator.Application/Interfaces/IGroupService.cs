using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chessinator.Application.Dtos;

namespace Chessinator.Application.Interfaces
{
    public interface IGroupService
    {
        public Task<GroupDto> CreateGroupAsync(GroupDto groupDto);

        public Task<List<GroupDto>> GetGroupsByTournamentIdAsync(Guid tournamentGuid);

        public Task<bool> DeleteGroupAsync(Guid groupGuid);

        public Task<GroupDto> UpdateGroupAsync(GroupDto groupDto);
    }
}
