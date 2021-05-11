using System;
using System.Collections.Generic;
using System.Text;
using Chessinator.Domain.Entities;

namespace Chessinator.Application.Dtos
{
    public class GroupDto
    {
        public Guid Id { get; set; }
        public Guid TournamentId { get; set; }
        public string Name { get; set; }
        public string Participant1 { get; set; }
        public string Participant2 { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();

    }
}
