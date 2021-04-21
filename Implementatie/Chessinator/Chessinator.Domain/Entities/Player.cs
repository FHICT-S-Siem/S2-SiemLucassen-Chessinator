using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinator.Domain.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }

        // EF Core 5.0 recognizes this as a many-to-many relationship by convention, and automatically creates a PlayerMatch join table in the database.
        public ICollection<Match> Matches { get; set; } = new List<Match>();
        public ICollection<Group> Groups { get; set; } = new List<Group>();
    }
}
