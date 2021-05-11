using System;
using System.Collections.Generic;
using System.Text;

namespace Chessinator.Application.Dtos
{
    public class ParticipantDto
    {
        public Guid Id { get; set; }
        public Guid TournamentId { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
    }
}
