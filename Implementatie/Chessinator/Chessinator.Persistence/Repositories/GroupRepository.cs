﻿using System;
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
    public class GroupRepository : IGroupRepository
    {
        private readonly ChessinatorDbContext _chessinatorDbContext;

        public GroupRepository(ChessinatorDbContext chessinatorDbContext)
        {
            _chessinatorDbContext = chessinatorDbContext;
        }

        public async Task<Group> CreateGroupAsync(Group group)
        {
            EntityEntry<Group> trackedGroup = await _chessinatorDbContext.Groups.AddAsync(group);
            await _chessinatorDbContext.SaveChangesAsync();
            return trackedGroup.Entity;
        }

        public async Task<List<Group>> GetGroupsByTournamentIdAsync(Guid tournamentGuid)
        {
            return await _chessinatorDbContext.Groups.Where(g => g.TournamentId == tournamentGuid).ToListAsync();
        }

        public async Task<bool> DoesGroupExist(string name)
        {
            return await _chessinatorDbContext.Groups.AnyAsync(g => g.Name == name || g.Participant1 == name || g.Participant2 == name);
        }

        public async Task<bool> DeleteGroupAsync(Guid groupGuid)
        {
            Group trackedGroup = await _chessinatorDbContext.Groups.FindAsync(groupGuid);
            _chessinatorDbContext.Groups.Remove(trackedGroup);
            int rowsChanged = await _chessinatorDbContext.SaveChangesAsync();
            return rowsChanged > 0;
        }

        public async Task<Group> UpdateGroupAsync(Group group)
        {
            Group trackedGroup = await _chessinatorDbContext.Groups.FindAsync(group.Id);

            if (trackedGroup != null)
            {
                trackedGroup.Name = group.Name;
                trackedGroup.Participant1 = group.Participant1;
                trackedGroup.Participant2 = group.Participant2;

                await _chessinatorDbContext.SaveChangesAsync();
            }

            return trackedGroup;
        }
    }
}
