using System;
using System.Collections.Generic;

namespace Chessinator.Domain.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public Guid TournamentId { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }

        // EF Core 5.0 recognizes this as a many-to-many relationship by convention, and automatically creates a PlayerMatch join table in the database.
        public List<Match> Matches { get; set; } = new List<Match>();
        public List<Group> Groups { get; set; } = new List<Group>();
        public List<GroupPlayer> GroupPlayers { get; set; } = new List<GroupPlayer>();
        public List<MatchPlayer> MatchPlayers { get; set; } = new List<MatchPlayer>();

    }
}
