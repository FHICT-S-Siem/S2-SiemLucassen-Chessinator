using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using AutoMapper;
using Chessinator.Application.Dtos;
using Chessinator.Application.Interfaces;
using Chessinator.Domain.Entities;
using Chessinator.Domain.Exceptions;

namespace Chessinator.Application.Services
{
    public class GroupService : IGroupService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupService(ITournamentRepository tournamentRepository ,IGroupRepository groupRepository ,IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _groupRepository = groupRepository;
            _mapper = mapper;
        }
        public async Task<GroupDto> CreateGroupAsync(GroupDto groupDto)
        {
            Group group = _mapper.Map<Group>(groupDto);
            Tournament trackedTournament = await _tournamentRepository.GetTournamentByIdAsync(groupDto.TournamentId);
            trackedTournament.Groups.Add(group);

            Group createdGroup = await _groupRepository.CreateGroupAsync(group);

            if (createdGroup == null)
                throw new ChessinatorException("Failed to create group");
            return _mapper.Map<GroupDto>(createdGroup);
        }

        public async Task<bool> DeleteGroupAsync(Guid groupGuid)
        {
            return await _groupRepository.DeleteGroupAsync(groupGuid);
        }

        public async Task<bool> DoesGroupExist(string name)
        {
            return await _groupRepository.DoesGroupExist(name);
        }

        public async Task<List<GroupDto>> GetGroupsByTournamentIdAsync(Guid tournamentGuid)
        {
            List<Group> groups = await _groupRepository.GetGroupsByTournamentIdAsync(tournamentGuid);

            return _mapper.Map<List<GroupDto>>(groups);
        }

        public async Task<GroupDto> UpdateGroupAsync(GroupDto groupDto)
        {
            Group group = _mapper.Map<Group>(groupDto);
            Group updatedGroup = await _groupRepository.UpdateGroupAsync(group);

            if (updatedGroup == null)
                throw new ChessinatorException("Failed to update group");
            return _mapper.Map<GroupDto>(updatedGroup);
        }
    }
}
