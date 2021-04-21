using System;
using System.Collections.Generic;
using System.Text;

namespace Chessinator.Domain.Entities
{
    public class Match
    {
        public Guid Id { get; set; }
        public Guid TournamentId { get; set; }
        public bool IsPlayed { get; set; }
        public bool Winner { get; set; }

        // EF Core 5.0 recognizes this as a many-to-many relationship by convention, and automatically creates a PlayerMatch join table in the database.
        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
