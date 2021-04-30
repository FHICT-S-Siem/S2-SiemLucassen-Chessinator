using System;
using System.Collections.Generic;
using System.Text;

namespace Chessinator.Application.Dtos
{
    public class GroupDto
    {
        public Guid Id { get; set; }
        public Guid TournamentId { get; set; }
        public string Participant { get; set; }
        public int Groups { get; set; }
        public int GroupSize { get; set; }
    }
}
