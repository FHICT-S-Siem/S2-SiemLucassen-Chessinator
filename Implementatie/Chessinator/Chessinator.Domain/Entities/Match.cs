using System;
using System.Collections.Generic;

namespace Chessinator.Domain.Entities
{
    public class Match
    {
        public Guid Id { get; set; }
        public Guid TournamentId { get; set; }
        public bool IsPlayed { get; set; }
        public bool Winner { get; set; }

        // EF Core 5.0 recognizes this as a many-to-many relationship by convention, and automatically creates a PlayerMatch join table in the database.
        public List<Player> Players { get; set; } = new List<Player>();
        public List<MatchPlayer> MatchPlayers { get; set; } = new List<MatchPlayer>();
    }
}
