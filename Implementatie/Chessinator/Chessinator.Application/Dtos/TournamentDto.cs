using System;
using System.Collections.Generic;
using Chessinator.Domain.Entities;

namespace Chessinator.Application.Dtos
{
    public class TournamentDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Seeding { get; set; }
        public string Time { get; set; }
        public DateTime DateTime { get; set; }
        public List<GroupDto> Groups { get; set; } = new List<GroupDto>();
        public List<ParticipantDto> Participants { get; set; } = new List<ParticipantDto>();
    }
}
