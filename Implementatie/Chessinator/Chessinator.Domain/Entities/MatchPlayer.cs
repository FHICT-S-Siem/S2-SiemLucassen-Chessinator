using System;
using System.Collections.Generic;
using System.Text;

namespace Chessinator.Domain.Entities
{
    public class MatchPlayer
    {
        public Guid PlayerId { get; set; }
        public Guid MatchId { get; set; }
        public Player Player { get; set; }
        public Match Match { get; set; }
    }
}
